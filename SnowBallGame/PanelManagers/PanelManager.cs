using System.Windows.Forms;

namespace SnowBallGame
{
	class PanelManager
	{
		public Control Entity { get; }

		public PanelManager(Control entity)
		{
			this.Entity = entity;
		}

		public void Hide() 
		{
			this.Entity.Visible = false;
		}

		public void Show()
		{
			this.Entity.Visible = true;
		}

		public void Register(Control entity)
		{
			Entity.Controls.Add(entity);
		}

		public void UnRegister(Control entity)
		{
			Entity.Controls.Remove(entity);
		}
	}
}
