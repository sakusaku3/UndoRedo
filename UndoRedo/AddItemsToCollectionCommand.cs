using System.Collections.Generic;
using System.Linq;

namespace UndoRedo
{
	public class AddItemsToCollectionCommand<T> : IUndoableCommand
	{
		private readonly SequentialCommand commands; 

		public AddItemsToCollectionCommand(
			IList<T> collection,
			IEnumerable<T> items)
		{
			this.commands = new SequentialCommand(
				items.Select(x => new AddItemToCollectionCommand<T>(collection, x)));
		}

		public void Execute() => this.commands.Execute();
		public void Undo() => this.commands.Undo();
		public void Redo() => this.commands.Redo();
	}
}
