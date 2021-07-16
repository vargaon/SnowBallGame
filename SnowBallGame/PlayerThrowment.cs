namespace SnowBallGame
{
	/// <summary>
	/// Class representing player's throwment data.
	/// </summary>
	sealed class PlayerThrowment
	{
		/// <summary>
		/// Function representing the type of ball thrown.
		/// </summary>
		/// <typeparam name="TBall"></typeparam>
		/// <returns>New instance of thrown ball according to TBall</returns>
		public delegate TBall ThrownBall<out TBall>() where TBall : Ball;

		private int _throwWait = Config.PLAYER_THROW_WAIT;

		private int _throwWaitCounter;

		private int _stackAmount = Config.PLAYER_STACK_AMOUNT;

		private int _stackAmountCounter;

		private ThrownBall<Ball> _thrownBall;

		/// <summary>
		/// Flag indicating if player can throw.
		/// </summary>
		public bool CanThrow { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="PlayerThrowment"/>.
		/// </summary>
		public PlayerThrowment()
		{
			this.CanThrow = true;
			ResetThrowWaitCounter();
			ResetStackAmountCounter();
		}

		/// <summary>
		/// Set <see cref="CanThrow"/> flag and call <see cref="ThrowBall"/>.
		/// </summary>
		/// <returns>Ball thrown.</returns>.
		public Ball ThrowBall()
		{
			this.CanThrow = false;
			return _thrownBall();
		}

		/// <summary>
		/// Set type of ball player will throw.
		/// </summary>
		/// <param name="thrownBall"></param>
		public void SetThrownBall(ThrownBall<Ball> thrownBall)
		{
			this._thrownBall = thrownBall;
		}

		/// <summary>
		/// Process one timer player throwment tick. 
		/// Decreases or resets inner throw wait counter.
		/// </summary>
		public void ThrowTick()
		{
			if (this.CanThrow) return;

			if(DecreaseThrowWaitCounter())
			{
				this.CanThrow = true;
				ResetThrowWaitCounter();
			}
		}

		private bool DecreaseThrowWaitCounter()
		{
			_throwWaitCounter -= 1;
			return _throwWaitCounter <= 0;
		}

		private void ResetThrowWaitCounter()
		{
			_throwWaitCounter = _throwWait;
		}

		/// <summary>
		/// Decreases stack amount counter.
		/// </summary>
		/// <returns>True if stack is empty.</returns>
		public bool DecreaseStackAmountCounter()
		{
			_stackAmountCounter -= 1;
			return _stackAmountCounter <= 0;
		}

		/// <summary>
		/// Resets stack amount counter to default set value.
		/// </summary>
		public void ResetStackAmountCounter()
		{
			_stackAmountCounter = _stackAmount;
		}

		/// <summary>
		/// Set throw wait counter.
		/// </summary>
		/// <param name="value">Number of ticks player wait to next throw.</param>
		public void SetThrowWait(int value)
		{
			this._throwWait = value;
		}

		/// <summary>
		/// After reseting player's bonus throwment set <see cref="CanThrow"/> flag to false for hold next throw. 
		/// </summary>
		public void HoldAThrow()
		{
			CanThrow = false;
			ResetThrowWaitCounter();
		}
	}
}
