using System;

namespace UndoRedo
{
	public class ClearValueCommand<T> : IUndoableCommand
	{
		private readonly Action<T> setValue;
		private readonly T currentValue;

		public ClearValueCommand(
			T currentValue,
			Action<T> setValue)
		{
			this.currentValue = currentValue;
			this.setValue = setValue;
		}

		public void Execute() => this.setValue.Invoke(default);
		public void Undo() => this.setValue.Invoke(this.currentValue);
		public void Redo() => this.setValue.Invoke(default);
	}
}
