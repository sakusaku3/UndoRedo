using System;

namespace UndoRedo
{
	public class SetValueCommand<T> : IUndoableCommand
	{
		private readonly Action<T> setValue;
		private readonly T oldValue;
		private readonly T newValue;

		public SetValueCommand(
			T oldValue,
			T newValue,
			Action<T> setValue)
		{
			this.oldValue = oldValue;
			this.newValue = newValue;
			this.setValue = setValue;
		}

		public void Execute() => this.setValue.Invoke(this.newValue);
		public void Undo() => this.setValue.Invoke(this.oldValue);
		public void Redo() => this.setValue.Invoke(this.newValue);
	}
}
