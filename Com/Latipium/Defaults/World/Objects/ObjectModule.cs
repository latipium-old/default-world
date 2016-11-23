// ObjectModule.cs
//
// Copyright (c) 2016 Zach Deibert.
// All Rights Reserved.
using System;
using System.Collections.Generic;
using Com.Latipium.Core;

namespace Com.Latipium.Defaults.World.Objects {
	/// <summary>
	/// The default module implementation for world objects.
	/// </summary>
	public class ObjectModule : AbstractLatipiumModule {
		private readonly Dictionary<string, LatipiumObject> Objects;
		/// <summary>
		/// Occurs when an object is loaded.
		/// </summary>
		[LatipiumMethod("ObjectLoaded")]
		public event Action<LatipiumObject> ObjectLoaded;

		/// <summary>
		/// Loads an object into the module
		/// </summary>
		/// <param name="obj">The object to load.</param>
		[LatipiumMethod("LoadObject")]
		public void Load(LatipiumObject obj) {
			Objects[obj.GetType().FullName] = obj;
			if ( ObjectLoaded != null ) {
				ObjectLoaded(obj);
			}
		}

		/// <summary>
		/// Gets an object by its fully-qualified name.
		/// </summary>
		/// <returns>The object.</returns>
		/// <param name="name">The name.</param>
		[LatipiumMethod("Get")]
		public LatipiumObject GetObject(string name) {
			if ( Objects.ContainsKey(name) ) {
				return Objects[name];
			} else {
				return null;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Com.Latipium.Defaults.World.Objects.ObjectModule"/> class.
		/// </summary>
		public ObjectModule() : base(new string[] { "Com.Latipium.Modules.World.Objects" }) {
			Objects = new Dictionary<string, LatipiumObject>();
		}
	}
}

