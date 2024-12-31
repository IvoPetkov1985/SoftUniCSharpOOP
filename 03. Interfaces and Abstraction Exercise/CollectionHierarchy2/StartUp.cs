using CollectionHierarchy2.Core;
using CollectionHierarchy2.Core.Contracts;
using CollectionHierarchy2.IO;
using CollectionHierarchy2.IO.Contracts;
using CollectionHierarchy2.Models;
using CollectionHierarchy2.Models.Contracts;

IReader reader = new ConsoleReader();
IWriter writer = new ConsoleWriter();
IAddCollection addCollection = new AddCollection();
IAddRemoveCollection addRemoveCollection = new AddRemoveCollection();
IMyList myList = new MyList();

IEngine engine = new Engine(reader, writer, addCollection, addRemoveCollection, myList);
engine.Run();
