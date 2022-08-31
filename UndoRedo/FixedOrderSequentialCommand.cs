using System.Collections.Generic;
using System.Linq;

namespace UndoRedo
{
	public class FixedOrderSequentialCommand : IUndoableCommand
	{
		private readonly List<IUndoableCommand> commands;

		public FixedOrderSequentialCommand() : this(Enumerable.Empty<IUndoableCommand>().ToArray()) { }

		public FixedOrderSequentialCommand(params IUndoableCommand[] commands)
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
			this.commands.ForEach(x => x.Undo());
		}

		public void Redo()
		{
			this.commands.ForEach(x => x.Redo());
		}
	}
}
