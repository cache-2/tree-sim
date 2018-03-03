using System;
using System.Collections.Generic;

namespace PickTrees {
	public class GameCore{
		Random rand = new Random();
		public static int money = 1000;
		public static int numOfTrees;
		static int deteriorate;
		public static int fruitCount;
		List<Tree> storage = new List<Tree>();
		string[] trees = new string[] {"orange","apple","lemon","banana"};
		string[] size = new string[] {"small","medium","large"};
		public void PlayGame() {
			//welcome
			Console.WriteLine ("Hello and welcome to Tree Simulator! A super fun text game where you grow and take care of trees. \n To start, just type 'buy tree' in to the console. \n From there, some more commands include \n check status (checks status of tree), \n water tree and harvest fruit which do those actions respectively. \n If you are stuck and cant remember the commands, just type 'help' in the console. \n With that said, have fun and grow some trees! \n Note: These commands are case sensitive!");
			//reads the line in the console until the user enters "quit"
			string Input = Console.ReadLine ();
			while (Input != "quit") {
				Input = Console.ReadLine ();
				if (Input == "buy tree")
					ChooseTree ();
				else if (Input == "check status")
					Check ();
				else if (Input == "water tree")
					Water ();
				else if (Input == "harvest fruit")
					Harvest ();
				else if (Input == "help")
					Console.WriteLine ("Here is the list of commands: \n harvest fruit \n water tree \n check status \n buy tree \n sell fruit \n check money");
//				else if (Input == "debug") {
//					Console.WriteLine (storage.Count);
//					foreach (Tree t in storage) {
//						Console.WriteLine (t.statPoints ["Health"]);
//						Console.WriteLine (t.statPoints ["fruit"]);
//					}
//					Console.WriteLine (fruitCount);
//					Console.WriteLine (money);
//				}
				else if (Input == "sell fruit")
					Sell ();
				else if (Input == "check money")
					CountMoney ();
				else {
					deteriorate += 1;
					if (deteriorate == 10 && storage.Count >= 1) {
						foreach (Tree t in storage) {
							t.statPoints ["Health"] -= 2;
						}
						storage [rand.Next (0, numOfTrees)].statPoints["fruit"] = 1;
						deteriorate = 0;
					} 
				}
			};
		}

		void Sell() {
			foreach (Tree t in storage) {
				money += (fruitCount * 20);
			}
			Console.WriteLine ("You now have " + money + " coins!");
			fruitCount = 0;
		}

		void CountMoney() {
			Console.WriteLine ("You currently have " + money + " coins.");
		}

		void Check() {
			foreach (Tree t in storage.ToArray()) {
				t.CheckStatus ();
				if (t.statPoints ["Health"] <= 0) {
					storage.Remove (t);
				}
			}
		}

		void Water() {
			//waters each tree (see tree class for more info)
			foreach (Tree t in storage) {
				t.water ();
			}
		}

		void Harvest() {
			//gets fruit from each tree (see tree class for more info)
			foreach (Tree t in storage) {
				t.HarvestFruit ();
			}
		}

		void ChooseTree() {
			Console.WriteLine ("Choose a type:");
			foreach (string i in trees) {
				Console.WriteLine (i);
			}
			string select1 = Console.ReadLine ();
			//Debug to ensure the user does not choose a random fruit. Statement will terminate if they do.
			if ((select1 == trees [0] || select1 == trees [1] || select1 == trees [2] || select1 == trees [3]) && money >= 100) {
				numOfTrees += 1;
				Tree tree = new Tree (select1);
				storage.Add (tree);
				money -= 100;
			} else if (money < 100) { 
				Console.WriteLine ("You dont have enough money to buy a tree.");
			} else {
				Console.WriteLine ("INVALID TREE TYPE!!!");	
			}
		}
	}
}