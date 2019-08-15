// <copyright file="PropertyHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SzwHighSpeedRack
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Text;

    /// <summary>
    /// 反射属性助手
    /// 作者：史梓威
    /// 创建时间：2019-05-08.
    internal class PropertyHelper
    {
        /// <summary>
        /// set缓存池.
        /// </summary>
        private static Dictionary<PropertyInfo, DynamicMethodHelper> setPool = new Dictionary<PropertyInfo, DynamicMethodHelper>();

        /// <summary>
        /// get缓存池.
        /// </summary>
        private static Dictionary<PropertyInfo, DynamicMethodHelper> getPool = new Dictionary<PropertyInfo, DynamicMethodHelper>();
        private static object lockhelper = new object();

        /// <summary>
        /// 增加属性
        /// </summary>
        /// <param name="t">类型</param>
        /// <param name="assemblyName">程序集名</param>
        /// <param name="propertyName">属性名</param>
        /// <param name="returnType">返回类型</param>
        /// <param name="parameterTypes">参数类型</param>
        public static void AddProperties(Type t, string assemblyName, string propertyName, Type returnType, params Type[] parameterTypes)
        {
            AssemblyBuilder ab = AssemblyBuilder.DefineDynamicAssembly(t.Assembly.GetName(), AssemblyBuilderAccess.Run);
            ModuleBuilder mb = ab.DefineDynamicModule(t.Assembly.GetName() + ".dll");
            TypeBuilder typeBuilder = mb.DefineType(t.Name, TypeAttributes.Public);
            FieldBuilder field = typeBuilder.DefineField("_" + propertyName, typeof(string), FieldAttributes.Private);
            PropertyBuilder property = typeBuilder.DefineProperty(propertyName, PropertyAttributes.None, returnType, parameterTypes);
            MethodAttributes getSetAttr = MethodAttributes.Public | MethodAttributes.HideBySig;
            MethodBuilder currGetPropMthdBldr = typeBuilder.DefineMethod("get_value", getSetAttr, typeof(string), Type.EmptyTypes);
            ILGenerator currGetIL = currGetPropMthdBldr.GetILGenerator();
            currGetIL.Emit(OpCodes.Ldarg_0);
            currGetIL.Emit(OpCodes.Ldfld, field);
            currGetIL.Emit(OpCodes.Ret);
            MethodBuilder currSetPropMthdBldr = typeBuilder.DefineMethod("set_value", getSetAttr, null, parameterTypes);
            ILGenerator currSetIL = currSetPropMthdBldr.GetILGenerator();
            currSetIL.Emit(OpCodes.Ldarg_0);
            currSetIL.Emit(OpCodes.Ldarg_1);
            currSetIL.Emit(OpCodes.Stfld, field);
            currSetIL.Emit(OpCodes.Ret);
            property.SetGetMethod(currGetPropMthdBldr);
            property.SetSetMethod(currSetPropMthdBldr);
        }

        /// <summary>
        /// 快速设置属性值.
        /// </summary>
        /// <param name="pi">pi.</param>
        /// <param name="instance">instance.</param>
        /// <param name="value">value.</param>
        public static void FastSetValue(PropertyInfo pi, object instance, object[] value)
        {
            lock (lockhelper)
            {
                if (!setPool.ContainsKey(pi))
                {
                    setPool.Add(pi, new DynamicMethodHelper(pi.GetSetMethod()));
                }

                ((DynamicMethodHelper)setPool[pi]).Execute(instance, value);
            }
        }

        /// <summary>
        /// 快速获取属性值.
        /// </summary>
        /// <param name="pi">属性片段.</param>
        /// <param name="instance">实体.</param>
        /// <returns>object.</returns>
        public static object FastGetValue(PropertyInfo pi, object instance)
        {
            lock (lockhelper)
            {
                if (!getPool.ContainsKey(pi))
                {
                    getPool.Add(pi, new DynamicMethodHelper(pi.GetGetMethod()));
                }

                return ((DynamicMethodHelper)getPool[pi]).Execute(instance, null);
            }
        }
    }
}
