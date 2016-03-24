using System;

using UnityEngine;

namespace AssemblyCSharp
{
	public class Enemy2Class
	{
		private int health;

		private Color color = Color.red;

		public Enemy2Class (int health, Color color)
		{

			this.health = health;

			this.color = color;
		}

		public int Health{
			get{ return health;}
			set{ health = value;}
		}
	}
}

