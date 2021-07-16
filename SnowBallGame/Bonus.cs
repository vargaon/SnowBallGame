using System.Windows.Forms;

namespace SnowBallGame
{
	/// <summary>
	/// Abstract class for all bonuse types.
	/// </summary>
	abstract class Bonus
	{
		/// <summary>
		/// Form control bonus entity.
		/// </summary>
		public Control Entity { get; }

		/// <summary>
		/// Bonus name.
		/// </summary>
		public string Name { get; protected set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Bonus"/>.
		/// </summary>
		/// <param name="entity"></param>
		public Bonus(Control entity) 
		{ 
			Entity = entity; 
		}

		/// <summary>
		/// Apply a bonus to the player.
		/// </summary>
		/// <param name="p">Player that collect the bonus.</param>
		abstract public void ApplyBonus(Player p);
	}

	abstract class PlayerBonus : Bonus
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PlayerBonus"/>.
		/// </summary>
		/// <param name="entity"><see cref="Bonus.Entity"/></param>
		public PlayerBonus(Control entity) : base(entity)
		{
		}

		/// <summary>
		/// Create a new instance of <see cref="PlayerMovement"/> and set its direction according to player movement.
		/// </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		protected PlayerMovement CreatePlayerMovement(Player p)
		{
			var movement = new PlayerMovement();
			movement.SetSameDirection(p.Movement);

			return movement;
		}
	}

	/// <summary>
	/// Extra live bonus. Add an extra live to player who collects the bonus.
	/// </summary>
	sealed class ExtraLiveBonus : PlayerBonus
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ExtraLiveBonus"/>.
		/// </summary>
		/// <param name="entity"><see cref="Bonus.Entity"/></param>
		public ExtraLiveBonus(Control entity) : base(entity) 
		{ 
			Name = Config.EXTRA_LIVE_NAME; 
			entity.BackColor = Config.EXTRA_LIVE_COLOR; 
		}

		public override void ApplyBonus(Player p)
		{
			p.AddLive();
		}
	}

	/// <summary>
	/// Giant size bonus. The player who collects the bonus will have a larger size and reduced movement speed
	/// </summary>
	sealed class GiantSizeBonus : PlayerBonus
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GiantSizeBonus"/>.
		/// </summary>
		/// <param name="entity"><see cref="Bonus.Entity"/></param>
		public GiantSizeBonus(Control entity) : base(entity)
		{
			Name = Config.GIANT_SIZE_NAME;
			entity.BackColor = Config.GIANT_SIZE_COLOR;
		}
		public override void ApplyBonus(Player p)
		{
			p.ResetPlayerBonus();
			p.SetBonusSize(Config.GIANT_SIZE_PLAYER_SIZE);
			var movement = CreatePlayerMovement(p);
			movement.SetMoveSpeed(Config.GIANT_SIZE_PLAYER_MOVE_SPEED);
			p.SetBonusMovement(movement);
			p.Profile.UpdateBonus(Name);
		}
	}

	/// <summary>
	/// Dwarf size bonus. The player who collects the bonus will have a smaller size and increased movement speed.
	/// </summary>
	sealed class DwarfSizeBonus : PlayerBonus
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DwarfSizeBonus"/>.
		/// </summary>
		/// <param name="entity"><see cref="Bonus.Entity"/></param>
		public DwarfSizeBonus(Control entity) : base(entity)
		{
			Name = Config.DWARF_SIZE_NAME;
			entity.BackColor = Config.DWARF_SIZE_COLOR;
		}

		public override void ApplyBonus(Player p)
		{
			p.ResetPlayerBonus();
			p.SetBonusSize(Config.DWARF_SIZE_PLAYER_SIZE);
			var movement = CreatePlayerMovement(p);
			movement.SetMoveSpeed(Config.DWARF_SIZE_PLAYER_MOVE_SPEED);
			p.SetBonusMovement(movement);
			p.Profile.UpdateBonus(Name);
		}
	}

	/// <summary>
	/// Jump boost bonus. 
	/// The player who collects the bonus will have increased <see cref="PlayerMovement.JumpSpeed"/> and <see cref="PlayerMovement.JumpForce"/>.
	/// </summary>
	sealed class JumpBoostBonus : PlayerBonus
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="JumpBoostBonus"/>.
		/// </summary>
		/// <param name="entity"><see cref="Bonus.Entity"/></param>
		public JumpBoostBonus(Control entity) : base(entity) 
		{ 
			Name = Config.JUMP_BOOST_NAME; 
			entity.BackColor = Config.JUMP_BOOST_COLOR; 
		}

		public override void ApplyBonus(Player p)
		{
			p.ResetPlayerBonus();
			var movement = CreatePlayerMovement(p);
			movement.SetJumpForce(Config.JUMP_BOOST_JUMP_FORCE);
			movement.SetJumpSpeed(Config.JUMP_BOOST_JUMP_SPEED);
			p.SetBonusMovement(movement);
			p.Profile.UpdateBonus(Name);
		}
	}

	/// <summary>
	/// Reverse gravity bonus. The player who collects the bonus will have reversed gravitation.
	/// </summary>
	sealed class ReverseGravity : PlayerBonus
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ReverseGravity"/>.
		/// </summary>
		/// <param name="entity"><see cref="Bonus.Entity"/></param>
		public ReverseGravity(Control entity) : base(entity)
		{
			Name = Config.REVERSE_GRAVITY_NAME;
			entity.BackColor = Config.REVERSE_GRAVITY_COLOR;
		}

		public override void ApplyBonus(Player p)
		{
			p.ResetPlayerBonus();
			var movement = CreatePlayerMovement(p);
			movement.ReverseGravity();
			p.Entity.Top -= 1;
			p.SetBonusMovement(movement);
			p.Profile.UpdateBonus(Name);
		}
	}

	/// <summary>
	/// Protection bonus. The player who collects the bonus will have reduced <see cref="PlayerMovement.PunchForce"/>.
	/// </summary>
	sealed class ProtectionBonus : PlayerBonus
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ProtectionBonus"/>.
		/// </summary>
		/// <param name="entity"><see cref="Bonus.Entity"/></param>
		public ProtectionBonus(Control entity) : base(entity) 
		{ 
			Name = Config.PROTECTION_NAME; 
			entity.BackColor = Config.PROTECTION_COLOR; 
		}

		public override void ApplyBonus(Player p)
		{
			p.ResetPlayerBonus();
			var movement = CreatePlayerMovement(p);
			movement.SetPunchForce(Config.PROTECTION_PUNCH_FORCE);
			p.SetBonusMovement(movement);
			p.Profile.UpdateBonus(Name);
		}
	}

	/// <summary>
	/// Abstract class for other ball bonuses.
	/// </summary>
	abstract class BallBonus : Bonus
	{
		protected BallFactory ballFactory;

		/// <summary>
		/// Initializes a new instance of the <see cref="BallBonus"/>.
		/// </summary>
		/// <param name="entity"><see cref="Bonus.Entity"/></param>
		/// <param name="factory">Ball factory for creating ball instance.</param>
		public BallBonus(Control entity, BallFactory factory) : base(entity) {
			ballFactory = factory;
		}
	}

	/// <summary>
	/// Ball bonus. Player who collects the bonus will throw new ball type according to <see cref="TBall"/>.
	/// </summary>
	/// <typeparam name="TBall"></typeparam>
	sealed class BallBonus<TBall> : BallBonus where TBall : Ball, new()
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="BallBonus{TBall}"/>.
		/// </summary>
		/// <param name="entity"><see cref="Bonus.Entity"/></param>
		/// <param name="factory">Ball factory for creating ball instance.</param>
		public BallBonus(Control entity, BallFactory factory) : base(entity, factory) 
		{ 
			Name = typeof(TBall).Name; 
			entity.BackColor = Config.BALL_BONUS_COLOR; 
		}

		public override void ApplyBonus(Player p)
		{
			var throwment = new PlayerThrowment();
			throwment.SetThrownBall(() => ballFactory.CreateBall<TBall>(p));
			p.SetBonusThrowment(throwment);
			p.Profile.UpdateBall(Name);
		}
	}
}
