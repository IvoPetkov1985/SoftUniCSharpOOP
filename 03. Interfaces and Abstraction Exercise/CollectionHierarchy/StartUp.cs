using CollectionHierarchy.Core;
using CollectionHierarchy.Core.Interfaces;
using CollectionHierarchy.Models;
using CollectionHierarchy.Models.Interfaces;

IAddCollection addCollection = new AddCollection();
IAddRemoveCollection addRemoveCollection = new AddRemoveCollection();
IMyList myList = new MyList();

IEngine engine = new Engine(addCollection, addRemoveCollection, myList);
engine.Run();
