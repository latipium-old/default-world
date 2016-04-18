// WorldModule.cs
//
// Copyright (c) 2016 Zach Deibert.
// All Rights Reserved.
using System;
using Com.Latipium.Core;

namespace Com.Latipium.Defaults.World {
	/// <summary>
	/// The default module implementation for worlds.
	/// </summary>
	public class WorldModule : AbstractLatipiumModule {
		/// <summary>
		/// Creates an empty world.
		/// </summary>
		/// <returns>The created world.</returns>
		[LatipiumMethod("CreateWorld")]
		public LatipiumObject ConstructWorld() {
			return new WorldImpl(this);
		}

		/// <summary>
		/// Constructs an object.
		/// </summary>
		/// <returns>The object.</returns>
		/// <param name="type">The type of object.</param>
		[LatipiumMethod("CreateObject")]
		public LatipiumObject ConstructObject(LatipiumObject type) {
			return new ObjectImpl(type);
		}

		/// <summary>
		/// Constructs an object.
		/// </summary>
		/// <returns>The object.</returns>
		/// <param name="type">The type of object.</param>
		/// <param name="guid">The object's guid.</param>
		[LatipiumMethod("CreateObject")]
		public LatipiumObject ConstructObject(LatipiumObject type, Guid guid) {
			return new ObjectImpl(type, guid);
		}

		/// <summary>
		/// Constructs a realm.
		/// </summary>
		/// <returns>The realm.</returns>
		/// <param name="name">The realm name.</param>
		[LatipiumMethod("CreateRealm")]
		public LatipiumObject ConstructRealm(string name) {
			return new RealmImpl(name);
		}

		/// <summary>
		/// Constructs a realm.
		/// </summary>
		/// <returns>The realm.</returns>
		/// <param name="name">The realm name.</param>
		/// <param name="guid">The guid of the realm.</param>
		[LatipiumMethod("CreateRealm")]
		public LatipiumObject ConstructRealm(string name, Guid guid) {
			return new RealmImpl(name, guid);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Com.Latipium.Defaults.World.WorldModule"/> class.
		/// </summary>
		public WorldModule() : base(new string[] { "Com.Latipium.Modules.World" }) {
		}
	}
}

