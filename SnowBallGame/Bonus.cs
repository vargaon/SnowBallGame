using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowBallGame
{
	abstract class Bonus
	{
		public Control Entity { get; }

		public string Name { get; protected set; }

		public Bonus(Control entity) 
		{ 
			Entity = entity; 
		}

		abstract public void AplyBonus(Player p);
	}

	class ExtraLiveBonus : Bonus
	{
		public ExtraLiveBonus(Control entity) : base(entity) 
		{ 
			Name = "ExtraLive"; 
			entity.BackColor = Color.Red; 
		}

		public override void AplyBonus(Player p)
		{
			p.AddLive();
		}
	}

	class GiantSizeBonus : Bonus
	{
		public GiantSizeBonus(Control entity) : base(entity)
		{
			Name = "GiantSize";
			entity.BackColor = Color.Purple;
		}

		public override void AplyBonus(Player p)
		{
			p.ResetBonusMovement();
			p.SetBonusSize(35);
			p.Profile.UpdateBonus(Name);
		}
	}

	class DwarfSizeBonus : Bonus
	{
		public DwarfSizeBonus(Control entity) : base(entity)
		{
			Name = "DwarfSize";
			entity.BackColor = Color.Purple;
		}

		public override void AplyBonus(Player p)
		{
			p.ResetBonusMovement();
			p.SetBonusSize(15);
			p.Profile.UpdateBonus(Name);
		}
	}

	class SpeedMovementBonus : Bonus
	{
		public SpeedMovementBonus(Control entity) :base(entity) 
		{ 
			Name = "SpeedBoost"; 
			entity.BackColor = Color.Blue; 
		}

		public override void AplyBonus(Player p)
		{
			p.ResetBonusMovement();
			var movement = new PlayerMovement();
			movement.SetMoveSpeed(15);
			p.SetBonusMovement(movement);
			p.Profile.UpdateBonus(Name);
		}
	}

	class JumpForceBonus : Bonus
	{
		public JumpForceBonus(Control entity) : base(entity) 
		{ 
			Name = "JumpBoost"; 
			entity.BackColor = Color.White; 
		}

		public override void AplyBonus(Player p)
		{
			p.ResetBonusMovement();
			var movement = new PlayerMovement();
			movement.SetJumpForce(10);
			p.SetBonusMovement(movement);
			p.Profile.UpdateBonus(Name);
		}
	}

	class ProtectionBonus : Bonus
	{
		public ProtectionBonus(Control entity) : base(entity) 
		{ 
			Name = "Protection"; 
			entity.BackColor = Color.Gray; 
		}

		public override void AplyBonus(Player p)
		{
			p.ResetBonusMovement();
			var movement = new PlayerMovement();
			movement.SetPunchForce(1);
			p.SetBonusMovement(movement);
			p.Profile.UpdateBonus(Name);
		}
	}

	abstract class BallBonus : Bonus
	{
		protected BallFactory ballFactory;
		public BallBonus(Control entity, BallFactory factory) : base(entity) {
			ballFactory = factory;
		}
	}

	class BallBonus<TBall> : BallBonus where TBall : Ball, new()
	{
		public BallBonus(Control entity, BallFactory factory) : base(entity, factory) 
		{ 
			Name = typeof(TBall).Name; 
			entity.BackColor = Color.Gold; 
		}

		public override void AplyBonus(Player p)
		{
			var throwment = new PlayerThrowment();
			throwment.SetThrownBall(() => ballFactory.CreateBall<TBall>(p));
			p.SetBonusThrowment(throwment);
			p.Profile.UpdateBall(Name);
		}
	}
}
