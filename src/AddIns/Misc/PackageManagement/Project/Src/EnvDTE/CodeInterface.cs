﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using ICSharpCode.SharpDevelop.Dom;

namespace ICSharpCode.PackageManagement.EnvDTE
{
	public class CodeInterface : CodeType
	{
		string fullName;
		
		public CodeInterface(IProjectContent projectContent, IClass c)
			: base(projectContent, c)
		{
			fullName = base.FullName;
		}
		
		public CodeInterface(IProjectContent projectContent, IReturnType type, IClass c)
			: base(projectContent, c)
		{
			fullName = GetFullName(type);
		}
		
		string GetFullName(IReturnType type)
		{
			return type.DotNetName.Replace("{", "<").Replace("}", ">");
		}
		
		/// <summary>
		/// Returns null if base type is not an interface.
		/// </summary>
		public static CodeInterface CreateFromBaseType(IProjectContent projectContent, IReturnType baseType)
		{
			IClass baseTypeClass = baseType.GetUnderlyingClass();
			if (baseTypeClass.ClassType == ClassType.Interface) {
				return new CodeInterface(projectContent, baseType, baseTypeClass);
			}
			return null;
		}
		
		public CodeFunction AddFunction(string name, vsCMFunction kind, object type, object Position = null, vsCMAccess Access = vsCMAccess.vsCMAccessPublic)
		{
			throw new NotImplementedException();
		}
		
		public override string FullName {
			get { return fullName; }
		}
	}
}
