using System.Windows.Forms;

namespace SnowBallGame
{
	/// <summary>
	/// Abstract class for panel managers.
	/// </summary>
	abstract class PanelManager
	{
		/// <summary>
		/// Form control entity.
		/// </summary>
		public Control Entity { get; }

		public PanelManager(Control entity)
		{
			this.Entity = entity;
		}

		/// <summary>
		/// Hides <see cref="Entity"/>, set its visibility to false.
		/// </summary>
		public void Hide() 
		{
			this.Entity.Visible = false;
		}

		/// <summary>
		/// Shows <see cref="Entity"/>, set its visibility to true.
		/// </summary>
		public void Show()
		{
			this.Entity.Visible = true;
		}

		/// <summary>
		/// Adds form control entity to <see cref="Entity"/> as child.
		/// </summary>
		/// <param name="entity">Form control</param>
		protected void Register(Control entity)
		{
			Entity.Controls.Add(entity);
		}

		/// <summary>
		/// Removes form control from <see cref="Entity"/>.
		/// </summary>
		/// <param name="entity">Form control</param>
		protected void UnRegister(Control entity)
		{
			Entity.Controls.Remove(entity);
		}
	}
}
