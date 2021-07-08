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

	abstract class MovementBonus : Bonus
	{
		public MovementBonus(Control entity) : base(entity)
		{
		}

		protected PlayerMovement CreatePlayerMovement(Player p)
		{
			var movement = new PlayerMovement();
			if (p.Movement.Direction < 0) movement.SetDirectionLeft();
			else movement.SetDirectionRight();

			return movement;
		}
	}

	class ExtraLiveBonus : MovementBonus
	{
		public ExtraLiveBonus(Control entity) : base(entity) 
		{ 
			Name = Config.EXTRA_LIVE_NAME; 
			entity.BackColor = Config.EXTRA_LIVE_COLOR; 
		}

		public override void AplyBonus(Player p)
		{
			p.AddLive();
		}
	}

	class GiantSizeBonus : MovementBonus
	{
		public GiantSizeBonus(Control entity) : base(entity)
		{
			Name = Config.GIANT_SIZE_NAME;
			entity.BackColor = Config.GIANT_SIZE_COLOR;
		}
		public override void AplyBonus(Player p)
		{
			p.ResetBonusMovement();
			p.SetBonusSize(Config.GIANT_SIZE_PLAYER_SIZE);
			var movement = CreatePlayerMovement(p);
			movement.SetMoveSpeed(Config.GIANT_SIZE_PLAYER_MOVE_SPEED);
			p.SetBonusMovement(movement);
			p.Profile.UpdateBonus(Name);
		}
	}

	class DwarfSizeBonus : MovementBonus
	{
		public DwarfSizeBonus(Control entity) : base(entity)
		{
			Name = Config.DWARF_SIZE_NAME;
			entity.BackColor = Config.DWARF_SIZE_COLOR;
		}

		public override void AplyBonus(Player p)
		{
			p.ResetBonusMovement();
			p.SetBonusSize(Config.DWARF_SIZE_PLAYER_SIZE);
			var movement = CreatePlayerMovement(p);
			movement.SetMoveSpeed(Config.DWARF_SIZE_PLAYER_MOVE_SPEED);
			p.SetBonusMovement(movement);
			p.Profile.UpdateBonus(Name);
		}
	}

	class JumpBoostBonus : MovementBonus
	{
		public JumpBoostBonus(Control entity) : base(entity) 
		{ 
			Name = Config.JUMP_BOOST_NAME; 
			entity.BackColor = Config.JUMP_BOOST_COLOR; 
		}

		public override void AplyBonus(Player p)
		{
			p.ResetBonusMovement();
			var movement = CreatePlayerMovement(p);
			movement.SetJumpForce(Config.JUMP_BOOST_JUMP_FORCE);
			movement.SetJumpSpeed(Config.JUMP_BOOST_JUMP_SPEED);
			p.SetBonusMovement(movement);
			p.Profile.UpdateBonus(Name);
		}
	}

	class ProtectionBonus : MovementBonus
	{
		public ProtectionBonus(Control entity) : base(entity) 
		{ 
			Name = Config.PROTECTION_NAME; 
			entity.BackColor = Config.PROTECTION_COLOR; 
		}

		public override void AplyBonus(Player p)
		{
			p.ResetBonusMovement();
			var movement = CreatePlayerMovement(p);
			movement.SetPunchForce(Config.PROTECTION_PUNCH_FORCE);
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
			entity.BackColor = Config.BALL_BONUS_COLOR; 
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
