using System;
using System.Collections.Generic;

namespace PickTrees{
	public class Tree {
		public string TypeOf;
		public string SizeOf;
		int WaterPts = 0;
		int count = 0;
		public int NumOfFruit;
		//A dictionary for storing health bar and if there is fruit
		public Dictionary<string, int> statPoints = new Dictionary<string, int> () {
			{"Health",6},
			{"fruit",0}
		};
		string[] scale = new string[] {"small","medium","large"};
		//Tree params on init
		public Tree(string typeOfTree){
			TypeOf = typeOfTree;
			string size = scale[count];
			SizeOf = size;
			Console.WriteLine("You now have a " + size + " " + typeOfTree + " tree.");
			//this is to randomize the health and fruit status of the tree, to keep things interesting
			Random rnd = new Random();
			statPoints ["Health"] -= rnd.Next (1, 4);
			statPoints ["fruit"] = rnd.Next(0,2);
			NumOfFruit = 0;
		}
		public void water() {
			//gives the tree more health
			Console.WriteLine ("You watered your " + SizeOf + " " + TypeOf + " tree!");
			statPoints ["Health"] += 2;
			WaterPts += 1;
			if (statPoints ["Health"] > 6) {
				//debug to make sure health is not greater than 6
				statPoints ["Health"] = 6;
			} else if (WaterPts == 15) {
				count += 1;
				WaterPts = 0;
				SizeOf = scale [count];
				Console.WriteLine ("Your tree is now a " + SizeOf + " tree!");
			}
		}

		public void CheckStatus() {
			//checks the health of the tree and if there is fruit
			string healthReport = (statPoints["Health"] >= 2 && statPoints["Health"] < 4) ? "Your " + SizeOf + " " + TypeOf + " tree is fine":(statPoints["Health"] >= 4) ? "Your " + SizeOf + " " + TypeOf +  " tree is in great condition" :(statPoints["Health"] <= 0) ? "Your " + SizeOf + " " + TypeOf +  " tree is dead... sorry" : "You might want to water your " + SizeOf + " " + TypeOf + " tree sometime soon";
			string Fruit = (statPoints["Health"] != 0) ? ((statPoints ["fruit"] == 1) ? "there is fruit on this tree!" : (statPoints["fruit"] == 0) ? "there is no fruit on this tree." : "" ):"no fruit will ever bear on this tree again.";
			Console.WriteLine(healthReport + " and " + Fruit);
		}
		public void HarvestFruit() {
			//enables you to harvest fruit and resets fruit status
			if (statPoints ["fruit"] == 1) {
				NumOfFruit = (SizeOf == "small") ? 2 : (SizeOf == "medium") ? 3 : 5;
				Console.WriteLine ("Fruit has been harvested from your " + SizeOf + " " + TypeOf + " tree!");
				statPoints ["fruit"] = 0;
			} else {
				Console.WriteLine ("There was no fruit on your " + SizeOf + " " + TypeOf + " tree");
				NumOfFruit = 0;
			}

			GameCore.fruitCount += NumOfFruit;
		}
	}
}