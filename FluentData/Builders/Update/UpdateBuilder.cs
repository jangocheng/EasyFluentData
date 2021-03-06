﻿using System;

namespace FluentData
{
    internal class UpdateBuilder : BaseUpdateBuilder, IUpdateBuilder, IInsertUpdateBuilder
    {
        internal UpdateBuilder(IDbProvider dbProvider, IDbCommand command, string name)
            : base(dbProvider, command, name) {
        }

        public virtual IUpdateBuilder Where(string columnName, object value, DataTypes parameterType, int size) {
            Actions.WhereAction(columnName, value, parameterType, size);
            return this;
        }

        public IUpdateBuilder Column(string columnName, object value, DataTypes parameterType, int size) {
            Actions.ColumnValueAction(columnName, value, parameterType, size);
            return this;
        }

        IInsertUpdateBuilder IInsertUpdateBuilder.Column(string columnName, object value, DataTypes parameterType, int size) {
            Actions.ColumnValueAction(columnName, value, parameterType, size);
            return this;
        }

        public IUpdateBuilder Fill(Action<IInsertUpdateBuilder> fillMethod) {
            fillMethod(this);
            return this;
        }

        public IUpdateBuilder AddWhere(string where) {
            Actions.AddWhereAction(where);
            return this;
        }
        public IUpdateBuilder AddWhereParam(string paramName, object value) {
            Actions.AddWhereParamAction(paramName, value);
            return this;
        }

    }
}
