// RealmImpl.cs
//
// Copyright (c) 2016 Zach Deibert.
// All Rights Reserved.
using System;
using System.Collections.Generic;
using Com.Latipium.Core;

namespace Com.Latipium.Defaults.World {
	/// <summary>
	/// The implementation of the realm instance interface
	/// </summary>
	public class RealmImpl : AbstractLatipiumObject {
		private readonly string Name;
		private readonly Guid Guid;
		private readonly LinkedList<LatipiumObject> Objects;
		private object WorldLock;

		/// <summary>
		/// Gets the objects in the world.
		/// </summary>
		/// <returns>The objects.</returns>
		[LatipiumMethod("GetObjects")]
		public IEnumerable<LatipiumObject> GetObjects() {
			return Objects;
		}

		/// <summary>
		/// Adds an object to the world.
		/// </summary>
		/// <param name="obj">The object.</param>
		[LatipiumMethod("AddObject")]
		public void AddObject(LatipiumObject obj) {
			lock ( WorldLock ) {
				Objects.AddLast(obj);
			}
		}

		/// <summary>
		/// Removes an object from the world.
		/// </summary>
		/// <param name="obj">The object.</param>
		[LatipiumMethod("RemoveObject")]
		public void RemoveObject(LatipiumObject obj) {
			lock ( WorldLock ) {
				Objects.Remove(obj);
			}
		}

		/// <summary>
		/// Gets the name of the realm.
		/// </summary>
		/// <returns>The realm name.</returns>
		[LatipiumMethod("Name")]
		public string GetName() {
			return Name;
		}

		/// <summary>
		/// Gets the GUID of the realm.
		/// </summary>
		/// <returns>The realm GUID.</returns>
		[LatipiumMethod("Guid")]
		public Guid GetGuid() {
			return Guid;
		}

		internal RealmImpl(string name) : this(name, Guid.NewGuid()) {
		}

		internal RealmImpl(string name, Guid guid) {
			Name = name;
			Guid = guid;
			Objects = new LinkedList<LatipiumObject>();
			WorldLock = new object();
		}
	}
}

