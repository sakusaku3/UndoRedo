using System;
using System.Collections.Generic;
using System.Linq;

namespace UndoRedo
{
	public class SequentialCommand : IUndoableCommand
	{
		private readonly List<IUndoableCommand> commands;

		public SequentialCommand() : this(Enumerable.Empty<IUndoableCommand>().ToArray()) { }

		public SequentialCommand(IEnumerable<IUndoableCommand> commands)
		{
			this.commands = commands.ToList();
		}

		public SequentialCommand(params IUndoableCommand[] commands)
		{
			this.commands = commands.ToList();
		}

		public void Append(IUndoableCommand command)
		{
			this.commands.Add(command);
		}

		public void Append(IEnumerable<IUndoableCommand> commands)
		{
			this.commands.AddRange(commands);
		}

		public void Execute()
		{
			this.commands.ForEach(x => x.Execute());
		}

		public void Undo()
		{
			var reversedCommands = ((IEnumerable<IUndoableCommand>)this.commands).Reverse();
			foreach (var command in reversedCommands)
			{
				command.Undo();
			}
		}

		public void Redo()
		{
			this.commands.ForEach(x => x.Redo());
		}
	}
}
