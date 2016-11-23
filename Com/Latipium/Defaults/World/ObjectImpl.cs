// ObjectImpl.cs
//
// Copyright (c) 2016 Zach Deibert.
// All Rights Reserved.
using System;
using System.Linq;
using Com.Latipium.Core;

namespace Com.Latipium.Defaults.World {
	/// <summary>
	/// The implementation of the object instance interface
	/// </summary>
	public class ObjectImpl : AbstractLatipiumObject {
		private readonly LatipiumObject Type;
		private readonly Guid Guid;
        private Com.Latipium.Core.Tuple<float, float, float> Position;
		private float[] Transform;

		/// <summary>
		/// Gets or sets the position of this object.
		/// </summary>
		/// <returns>The position</returns>
		/// <param name="val">The new position.</param>
		[LatipiumMethod("Position")]
        public Com.Latipium.Core.Tuple<float, float, float> GetSetPosition(Com.Latipium.Core.Tuple<float, float, float> val = null) {
			if ( val != null ) {
				Position = val;
			}
			return Position;
		}

		/// <summary>
		/// Gets or sets the transform of this object.
		/// </summary>
		/// <returns>The transform.</returns>
		/// <param name="val">The new transformation.</param>
		[LatipiumMethod("Transform")]
		public float[] GetSetTransform(float[] val = null) {
			if ( val != null && val.Length == 16 ) {
				Transform = val;
			}
			return Transform;
		}

		/// <summary>
		/// Multiplies a transformation onto the transform matrix.
		/// </summary>
		/// <param name="matrix">The factor matrix.</param>
		[LatipiumMethod("ApplyTransform")]
		public void ApplyTransformation(float[] matrix) {
			if ( matrix != null && matrix.Length == 16 ) {
				GetSetTransform(new float[] {
					Transform[0 * 4 + 0] * matrix[0 * 4 + 0] + Transform[1 * 4 + 0] * matrix[0 * 4 + 1] + Transform[2 * 4 + 0] * matrix[0 * 4 + 2] + Transform[3 * 4 + 0] * matrix[0 * 4 + 3],
					Transform[0 * 4 + 1] * matrix[0 * 4 + 0] + Transform[1 * 4 + 1] * matrix[0 * 4 + 1] + Transform[2 * 4 + 1] * matrix[0 * 4 + 2] + Transform[3 * 4 + 1] * matrix[0 * 4 + 3],
					Transform[0 * 4 + 2] * matrix[0 * 4 + 0] + Transform[1 * 4 + 2] * matrix[0 * 4 + 1] + Transform[2 * 4 + 2] * matrix[0 * 4 + 2] + Transform[3 * 4 + 2] * matrix[0 * 4 + 3],
					Transform[0 * 4 + 3] * matrix[0 * 4 + 0] + Transform[1 * 4 + 3] * matrix[0 * 4 + 1] + Transform[2 * 4 + 3] * matrix[0 * 4 + 2] + Transform[3 * 4 + 3] * matrix[0 * 4 + 3],

					Transform[0 * 4 + 0] * matrix[1 * 4 + 0] + Transform[1 * 4 + 0] * matrix[1 * 4 + 1] + Transform[2 * 4 + 0] * matrix[1 * 4 + 2] + Transform[3 * 4 + 0] * matrix[1 * 4 + 3],
					Transform[0 * 4 + 1] * matrix[1 * 4 + 0] + Transform[1 * 4 + 1] * matrix[1 * 4 + 1] + Transform[2 * 4 + 1] * matrix[1 * 4 + 2] + Transform[3 * 4 + 1] * matrix[1 * 4 + 3],
					Transform[0 * 4 + 2] * matrix[1 * 4 + 0] + Transform[1 * 4 + 2] * matrix[1 * 4 + 1] + Transform[2 * 4 + 2] * matrix[1 * 4 + 2] + Transform[3 * 4 + 2] * matrix[1 * 4 + 3],
					Transform[0 * 4 + 3] * matrix[1 * 4 + 0] + Transform[1 * 4 + 3] * matrix[1 * 4 + 1] + Transform[2 * 4 + 3] * matrix[1 * 4 + 2] + Transform[3 * 4 + 3] * matrix[1 * 4 + 3],

					Transform[0 * 4 + 0] * matrix[2 * 4 + 0] + Transform[1 * 4 + 0] * matrix[2 * 4 + 1] + Transform[2 * 4 + 0] * matrix[2 * 4 + 2] + Transform[3 * 4 + 0] * matrix[2 * 4 + 3],
					Transform[0 * 4 + 1] * matrix[2 * 4 + 0] + Transform[1 * 4 + 1] * matrix[2 * 4 + 1] + Transform[2 * 4 + 1] * matrix[2 * 4 + 2] + Transform[3 * 4 + 1] * matrix[2 * 4 + 3],
					Transform[0 * 4 + 2] * matrix[2 * 4 + 0] + Transform[1 * 4 + 2] * matrix[2 * 4 + 1] + Transform[2 * 4 + 2] * matrix[2 * 4 + 2] + Transform[3 * 4 + 2] * matrix[2 * 4 + 3],
					Transform[0 * 4 + 3] * matrix[2 * 4 + 0] + Transform[1 * 4 + 3] * matrix[2 * 4 + 1] + Transform[2 * 4 + 3] * matrix[2 * 4 + 2] + Transform[3 * 4 + 3] * matrix[2 * 4 + 3],

					Transform[0 * 4 + 0] * matrix[3 * 4 + 0] + Transform[1 * 4 + 0] * matrix[3 * 4 + 1] + Transform[2 * 4 + 0] * matrix[3 * 4 + 2] + Transform[3 * 4 + 0] * matrix[3 * 4 + 3],
					Transform[0 * 4 + 1] * matrix[3 * 4 + 0] + Transform[1 * 4 + 1] * matrix[3 * 4 + 1] + Transform[2 * 4 + 1] * matrix[3 * 4 + 2] + Transform[3 * 4 + 1] * matrix[3 * 4 + 3],
					Transform[0 * 4 + 2] * matrix[3 * 4 + 0] + Transform[1 * 4 + 2] * matrix[3 * 4 + 1] + Transform[2 * 4 + 2] * matrix[3 * 4 + 2] + Transform[3 * 4 + 2] * matrix[3 * 4 + 3],
					Transform[0 * 4 + 3] * matrix[3 * 4 + 0] + Transform[1 * 4 + 3] * matrix[3 * 4 + 1] + Transform[2 * 4 + 3] * matrix[3 * 4 + 2] + Transform[3 * 4 + 3] * matrix[3 * 4 + 3]
				});
			}
		}

		/// <summary>
		/// Rotates this object around the specified object.
		/// </summary>
		/// <param name="w">The angle to rotate.</param>
		/// <param name="x">The x component of the axis to render on.</param>
		/// <param name="y">The y component of the axis to render on.</param>
		/// <param name="z">The z component of the axis to render on.</param>
		[LatipiumMethod("Rotate")]
		public void Rotate(float w, float x, float y, float z) {
			float mag = (float) Math.Sqrt(x * x + y * y + z * z);
			x /= mag;
			y /= mag;
			z /= mag;
			float sin = (float) Math.Sin(w);
			float cos = (float) Math.Cos(w);
			float oneMinusCos = 1 - cos;
			float xOneMinusCos = x * oneMinusCos;
			float yOneMinusCos = y * oneMinusCos;
			float zOneMinusCos = z * oneMinusCos;
			float xy = x * yOneMinusCos;
			float yz = y * zOneMinusCos;
			float xz = z * xOneMinusCos;
			float xsin = x * sin;
			float ysin = y * sin;
			float zsin = z * sin;
			ApplyTransformation(new float[] {
				x * xOneMinusCos + cos, xy - zsin,              xz + ysin,              0,
				xy + zsin,              y * yOneMinusCos + cos, yz - xsin,              0,
				xz - ysin,              yz + xsin,              z * zOneMinusCos + cos, 0,
				0,                      0,                      0,                      1
			});
		}

		/// <summary>
		/// Gets the type of object this is.
		/// </summary>
		/// <returns>The type.</returns>
		[LatipiumMethod("Type")]
		public LatipiumObject GetObjectType() {
			return Type;
		}

		/// <summary>
		/// Gets the GUID of this object.
		/// </summary>
		/// <returns>The GUID.</returns>
		[LatipiumMethod("Guid")]
		public Guid GetGuid() {
			return Guid;
		}

		internal ObjectImpl(LatipiumObject type) : this(type, Guid.NewGuid()) {
		}

		internal ObjectImpl(LatipiumObject type, Guid guid) {
			Type = type;
			Guid = guid;
            Position = new Com.Latipium.Core.Tuple<float, float, float>(0, 0, 0);
			Transform = new float[] {
				1, 0, 0, 0,
				0, 1, 0, 0,
				0, 0, 1, 0,
				0, 0, 0, 1
			};
		}
	}
}

