using System.Collections.Generic;
using System.Linq;
using Reactive.Bindings;

namespace UndoRedo
{
	public class CommandOwner
	{
		public ReactiveProperty<bool> CanUndo { get; }
		public ReactiveProperty<bool> CanRedo { get; }

		private readonly Stack<IUndoableCommand> undoStack = new();
		private readonly Stack<IUndoableCommand> redoStack = new();

		public CommandOwner()
		{
			this.CanUndo = new ReactiveProperty<bool>(false);
			this.CanRedo = new ReactiveProperty<bool>(false);
		}

		public void Execute(IUndoableCommand command)
		{
			command.Execute();

			this.undoStack.Push(command);
			this.CanUndo.Value = true;

			this.redoStack.Clear();
			this.CanRedo.Value = false;
		}

		public void Undo()
		{
			if (!this.undoStack.Any()) return;
			var command = this.undoStack.Pop();
			this.CanUndo.Value = this.undoStack.Count > 0;

			command.Undo();

			this.redoStack.Push(command);
			this.CanRedo.Value = true;
		}

		public void Redo()
		{
			if (!this.redoStack.Any()) return;
			var command = this.redoStack.Pop();
			this.CanRedo.Value = this.redoStack.Count > 0;

			command.Redo();

			this.undoStack.Push(command);
			this.CanUndo.Value = true;
		}
	}
}
