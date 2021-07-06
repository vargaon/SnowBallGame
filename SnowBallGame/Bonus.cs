using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowBallGame
{
	abstract class Bonus
	{
		public Control Entity { get; protected set; }

		public string Name { get; protected set; }

		public Bonus(Control entity) { Entity = entity; }
		abstract public void AplyBonus(Player p);
	}

	class SpeedMovementBonus : Bonus
	{
		public SpeedMovementBonus(Control entity) :base(entity) { Name = "Speed"; }

		public override void AplyBonus(Player p)
		{
			var movement = new PlayerMovement(p.Movement.MoveSpeed * 2);
			p.SetBonusMovement(movement);
		}
	}

	class ProtectionBonus : Bonus
	{
		public ProtectionBonus(Control entity) : base(entity) { Name = "Protection"; }

		public override void AplyBonus(Player p)
		{
			p.Movement.SetPunchForce(p.Movement.PunchForce / 2);
		}
	}

	abstract class BallBonus : Bonus
	{
		protected BallFactory ballFactory;
		public BallBonus(Control entity, BallFactory factory) : base(entity) {
			ballFactory = factory;
		}
	}

	class BallBonus<TBall> : BallBonus where TBall : SnowBall, new()
	{
		public BallBonus(Control entity, BallFactory factory) : base(entity, factory) { Name = typeof(TBall).Name; }

		public override void AplyBonus(Player p)
		{
			var throwment = new PlayerThrowment();
			throwment.SetThrownBall(() => ballFactory.CreateBall<TBall>(p));
			p.SetBonusThrowment(throwment);
		}
	}
}
