﻿using NPoco;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace Umbraco.Core.Persistence.Dtos
{
    [TableName(Constants.DatabaseSchema.Tables.DataType)]
    [PrimaryKey("pk")]
    [ExplicitColumns]
    internal class DataTypeDto
    {
        [Column("pk")]
        [PrimaryKeyColumn(IdentitySeed = 40)]
        public int PrimaryKey { get; set; }

        [Column("nodeId")]
        [ForeignKey(typeof(NodeDto))]
        [Index(IndexTypes.UniqueNonClustered)]
        public int DataTypeId { get; set; }

        [Column("propertyEditorAlias")]
        public string EditorAlias { get; set; }

        [Column("dbType")]
        [Length(50)]
        public string DbType { get; set; }//NOTE Is set to [varchar] (50) in Sql Server script

        [ResultColumn]
        [Reference(ReferenceType.OneToOne, ColumnName = "DataTypeId")]
        public NodeDto NodeDto { get; set; }
    }
}