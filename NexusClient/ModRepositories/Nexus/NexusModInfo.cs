﻿using System;
using System.Runtime.Serialization;
using Nexus.Client.Mods;

namespace Nexus.Client.ModRepositories.Nexus
{
	/// <summary>
	/// Describes the metadata of a mod in the Nexus repository.
	/// </summary>
	[DataContract]
	public class NexusModInfo
	{
		#region Properties

		/// <summary>
		/// Gets or sets whether the mod contains adult material.
		/// </summary>
		/// <value>Whether the mod contains adult material.</value>
		[DataMember(Name = "adult")]
		public bool IsAdult { get; set; }

		/// <summary>
		/// Gets or sets the category of the mod.
		/// </summary>
		/// <value>The category of the mod.</value>
		[DataMember(Name = "category_id")]
		public Int32 CategoryId { get; set; }

		/// <summary>
		/// Gets or sets the description of the mod.
		/// </summary>
		/// <value>The description of the mod.</value>
		[DataMember(Name = "description")]
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the Id of the mod.
		/// </summary>
		/// <value>The Id of the mod.</value>
		[DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets the last updated date of the mod.
		/// </summary>
		/// <value>The last updated date of the mod.</value>
		[DataMember(Name = "lastupdate")]
		public DateTime LastUpdated { get; set; }

		/// <summary>
		/// Gets or sets the name of the mod.
		/// </summary>
		/// <value>The name of the mod.</value>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the author of the mod.
		/// </summary>
		/// <value>The author of the mod.</value>
		[DataMember(Name = "author")]
		public string Author { get; set; }

		/// <summary>
		/// Gets or sets the owner of the mod.
		/// </summary>
		/// <value>The owner of the mod.</value>
		[DataMember(Name = "owner_id")]
		public Int32 OwnerId { get; set; }

		/// <summary>
		/// Gets or sets the summary of the mod.
		/// </summary>
		/// <value>The summary of the mod.</value>
		[DataMember(Name = "summary")]
		public string Summary { get; set; }

		/// <summary>
		/// Gets or sets the human readable mod version.
		/// </summary>
		/// <value>The human readable mod version.</value>
		[DataMember(Name = "version")]
		public string HumanReadableVersion { get; set; }

		#endregion
	}
}