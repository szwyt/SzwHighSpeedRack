// <copyright file="EmitMapperExtension.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SzwHighSpeedRack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using EmitMapper;
    using EmitMapper.MappingConfiguration;

    /// <summary>
    /// 对象转换扩展.
    /// </summary>
    public class EmitMapperExtension : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmitMapperExtension"/> class.
        /// </summary>
        public EmitMapperExtension()
        {
            this.OwnDefaultMapConfigs = this.OwnDefaultMapConfig();
            this.OMM = new ObjectMapperManager();
        }

        public ObjectMapperManager OMM { get; set; }

        private DefaultMapConfig OwnDefaultMapConfigs { get; set; }

        public void SetConvertUsing<TFrom, To>(Func<TFrom, To> converter)
        {
            this.OwnDefaultMapConfigs.ConvertUsing(converter);
        }

        public DefaultMapConfig OwnDefaultMapConfig()
        {
            return new DefaultMapConfig().MatchMembers((x, y) =>
            {
                return x == y;
            });
        }

        public List<T> I2E<F, T>(List<F> entity)
        {
            return this.MapperList<F, T>(entity);
        }

        public List<T> E2I<F, T>(List<F> entity)
        {
            return this.MapperList<F, T>(entity);
        }

        public T I2E<F, T>(F entity)
        {
            return this.Mapper<F, T>(entity);
        }

        public T E2I<F, T>(F entity)
        {
            return this.Mapper<F, T>(entity);
        }

        public List<T> MapperList<F, T>(List<F> entity)
        {
            return entity.Select(s => this.Mapper<F, T>(s)).ToList();
        }

        public T Mapper<F, T>(F entity)
        {
            return this.OMM.GetMapper<F, T>(this.OwnDefaultMapConfigs).Map(entity);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            GC.Collect();
            GC.SuppressFinalize(this);
        }
    }
}
