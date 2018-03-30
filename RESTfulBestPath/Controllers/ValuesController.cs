using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RESTfulBestPath.Models;

namespace RESTfulBestPath.Controllers
{
	[Route("api/[controller]")]
	public class NapsController : Controller
	{
		// GET api/values LEAVE FOR SANITY CHECK----------
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "NapsController working", "GET" };
		}
	}

	[Route("api/[controller]")]
	public class mapsController : Controller
	{
		private readonly MapsContext _context;

		//Sample Map generator:
		static NodeMap getMap()
		{
			NodeMap testMap6Nodes = new NodeMap();
			testMap6Nodes.ID = "test";
			for (var i = 'a'; i < 'g'; i++)
			{
				var n = new Node(i.ToString());
				testMap6Nodes.allNodes.Add(i.ToString(), n);
			}
			testMap6Nodes.allNodes["a"].nodeDictionary.Add("b", 4);
			testMap6Nodes.allNodes["a"].nodeDictionary.Add("c", 2);
			testMap6Nodes.allNodes["b"].nodeDictionary.Add("a", 4);
			testMap6Nodes.allNodes["b"].nodeDictionary.Add("e", 5);
			testMap6Nodes.allNodes["c"].nodeDictionary.Add("a", 2);
			testMap6Nodes.allNodes["c"].nodeDictionary.Add("f", 1);
			testMap6Nodes.allNodes["c"].nodeDictionary.Add("d", 3);
			testMap6Nodes.allNodes["f"].nodeDictionary.Add("c", 1);
			testMap6Nodes.allNodes["d"].nodeDictionary.Add("e", 1);
			testMap6Nodes.allNodes["d"].nodeDictionary.Add("c", 3);
			testMap6Nodes.allNodes["e"].nodeDictionary.Add("d", 1);
			testMap6Nodes.allNodes["e"].nodeDictionary.Add("b", 5);
			return testMap6Nodes;
		}
		public mapsController(MapsContext context)
		{
			_context = context;

			if (_context.MapsDB.Count() == 0)
			{
				_context.MapsDB.Add(getMap()); //add a sample map if empty
				_context.SaveChanges();
			}
		}

		[HttpGet("{id}/path/{start}/{end}")]
		public IActionResult Get(string id, string start, string end)
		{
			NodeMap item = null;
			item = _context.MapsDB.FirstOrDefault(t => t.ID == id);
			if (item == null)
			{
				return NotFound("Map ID not found");
			}
			bool validStart = item.allNodes.ContainsKey(start);
			bool validEnd = item.allNodes.ContainsKey(end);
			if (!validStart || !validEnd)
			{
				return NotFound("Start or end ID not found!");
			}
			Node testNode = item.allNodes[start];
			Node testnode2 = item.allNodes["e"];
			BestPathDirections returnObjectUnserialized =
				item.getBestPath(item.allNodes[start], item.allNodes[end]);
			string jsonTestSer = JsonConvert.SerializeObject(returnObjectUnserialized);
			return new ObjectResult(returnObjectUnserialized);
			//now that we have the result...

		}
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "SUCCESS: mapsController working", "GET" };
		}
		// PUT api/values/5
		[HttpPut("{id}")]
		public IActionResult Put(string id, [FromBody]string value)
		{
			if (value == null || !value.Contains("nodes"))
			{
				return BadRequest();
			}
			IncomingNodeListJSON testing = JsonConvert.DeserializeObject<IncomingNodeListJSON>(value);
			testing.ID = id;
			NodeMap nodeMap = new NodeMap(id);

			foreach (string name in testing.nodes.Keys)
			{
				Node n = new Node(name);
				foreach (var pair in testing.nodes[name])
				{
					n.nodeDictionary.Add(pair.Key, pair.Value);
				}
				_context.MapsDB.Add(nodeMap);
				_context.SaveChanges();

				Console.WriteLine("PUT ID: {0}", id);
				Console.WriteLine(testing);
				return Ok();

			}
			return BadRequest();
		}
	}
}


