// WorldImpl.cs
//
// Copyright (c) 2016 Zach Deibert.
// All Rights Reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using Com.Latipium.Core;

namespace Com.Latipium.Defaults.World {
	/// <summary>
	/// The implementation of the world interface
	/// </summary>
	public class WorldImpl : AbstractLatipiumObject {
		private readonly List<LatipiumObject> Realms;
		private readonly Dictionary<string, LatipiumObject> Players;
		private readonly WorldModule WorldModule;
		private readonly LatipiumModule PlayerModule;
		private readonly Func<LatipiumObject> GetPlayer;
		private object WorldLock;

		/// <summary>
		/// Gets a player.
		/// </summary>
		/// <returns>The player.</returns>
		/// <param name="name">The name of the player.</param>
		[LatipiumMethod("GetPlayer")]
		public LatipiumObject GetPlayerInstance(string name) {
			lock ( WorldLock ) {
				if ( Players.ContainsKey(name) ) {
					return Players[name];
				} else if ( GetPlayer == null ) {
					return null;
				} else {
					LatipiumObject player = GetPlayer();
					LatipiumObject obj = WorldModule.ConstructObject(player);
					Realms.First().InvokeProcedure<LatipiumObject>("AddObject", obj);
					//player.InvokeFunction<string, string>("Name", name);
					//player.InvokeFunction<LatipiumObject, LatipiumObject>("Object", obj);
					return Players[name] = obj;
				}
			}
		}

		/// <summary>
		/// Gets the realms in the world.
		/// </summary>
		/// <returns>The realms.</returns>
		[LatipiumMethod("GetRealms")]
		public IEnumerable<LatipiumObject> GetRealms() {
			return Realms;
		}

        /// <summary>
        /// Adds a realm to the world.
        /// </summary>
        /// <param name="realm">The realm.</param>
		[LatipiumMethod("AddRealm")]
		public void AddRealm(LatipiumObject realm) {
			lock ( WorldLock ) {
				Realms.Add(realm);
			}
		}

		internal WorldImpl(WorldModule world) {
			Realms = new List<LatipiumObject>();
			Players = new Dictionary<string, LatipiumObject>();
			WorldModule = world;
			PlayerModule = ModuleFactory.FindModule("Com.Latipium.Modules.Player");
			if ( PlayerModule == null ) {
				GetPlayer = null;
			} else {
				GetPlayer = PlayerModule.GetFunction<LatipiumObject>("GetPlayer");
			}
			WorldLock = new object();
		}
	}
}

