// GeneratorModule.cs
//
// Copyright (c) 2016 Zach Deibert.
// All Rights Reserved.
using System;
using Com.Latipium.Core;

namespace Com.Latipium.Defaults.World.Generator {
	/// <summary>
	/// The default module implementation for the world generator.
	/// </summary>
	public class GeneratorModule : AbstractLatipiumModule {
		private LatipiumModule WorldModule;
		private Func<LatipiumObject> CreateWorld;
		private Func<string, LatipiumObject> CreateRealm;
		private Func<LatipiumObject, LatipiumObject> CreateObject;
		private LatipiumModule ObjectModule;
		private Func<string, LatipiumObject> GetObject;

		/// <summary>
		/// Generate a world.
		/// </summary>
		/// <returns>The generated world</returns>
		[LatipiumMethod("Generate")]
		public LatipiumObject Generate() {
			if ( CreateWorld == null || CreateRealm == null || CreateObject == null ) {
				return null;
			}
			LatipiumObject world = CreateWorld();
			LatipiumObject realm = CreateRealm("Com.Latipium.Realms.Default");
			world.InvokeProcedure<LatipiumObject>("AddRealm", realm);
			LatipiumObject cube = CreateObject(GetObject("Com.Latipium.TestingObjects.CubeObject"));
			realm.InvokeProcedure<LatipiumObject>("AddObject", cube);
			return world;
		}

        /// <summary>
        /// Loads the module.
        /// </summary>
        /// <param name="name">The module name.</param>
		public override void Load(string name) {
			WorldModule = ModuleFactory.FindModule("Com.Latipium.Modules.World");
			if ( WorldModule != null ) {
				CreateWorld = WorldModule.GetFunction<LatipiumObject>("CreateWorld");
				CreateRealm = WorldModule.GetFunction<string, LatipiumObject>("CreateRealm");
				CreateObject = WorldModule.GetFunction<LatipiumObject, LatipiumObject>("CreateObject");
			}
			ObjectModule = ModuleFactory.FindModule("Com.Latipium.Modules.World.Objects");
			if ( ObjectModule != null ) {
				GetObject = ObjectModule.GetFunction<string, LatipiumObject>("Get");
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Com.Latipium.Defaults.World.Generator.GeneratorModule"/> class.
		/// </summary>
		public GeneratorModule() : base(new string[] { "Com.Latipium.Modules.World.Generator" }) {
		}
	}
}

