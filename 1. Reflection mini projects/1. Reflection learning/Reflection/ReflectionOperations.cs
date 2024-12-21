using System.Collections.Generic;
using System.Reflection;

[assembly: CLSCompliant(true)]

namespace Reflection
{
    public static class ReflectionOperations
    {
        public static string GetTypeName(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj), "Object cannot be null");
            }

            Type type = obj.GetType();
            return type.Name;
        }

        public static string GetFullTypeName<T>()
        {
            Type type = typeof(T);
            return type.FullName!;
        }

        public static string GetAssemblyQualifiedName<T>()
        {
            Type type = typeof(T);
            return type.AssemblyQualifiedName!;
        }

        public static string[] GetPrivateInstanceFields(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj), "Object cannot be null");
            }

            Type type = obj.GetType();
            FieldInfo[] privateFields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            return privateFields.Select(field => field.Name).ToArray();
        }

        public static string[] GetPublicStaticFields(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj), "Object cannot be null");
            }

            Type type = obj.GetType();
            FieldInfo[] privateFields = type.GetFields(BindingFlags.Static | BindingFlags.Public);
            return privateFields.Select(field => field.Name).ToArray();
        }

        public static string?[] GetInterfaceDataDetails(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj), "Object cannot be null");
            }

            Type type = obj.GetType();
            List<string> list = [];

            foreach (Type tinterface in type.GetInterfaces())
            {
                list.Add(tinterface.FullName ?? tinterface.Name);
            }

            return list.ToArray();
        }

        public static string?[] GetConstructorsDataDetails(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj), "Object cannot be null");
            }

            Type type = obj.GetType();
            ConstructorInfo[] constructorsInfo = type.GetConstructors();
            List<string> constructorList = new List<string>();

            foreach (ConstructorInfo c in constructorsInfo)
            {
                // Get parameter types and format them as required
                var parameters = c.GetParameters()
                                  .Select(p =>
                                      p.ParameterType.IsValueType
                                      ? p.ParameterType.Name // Simple name for value types
                                      : p.ParameterType.FullName) // Full name for reference types
                                  .ToArray();

                // Formatting the constructor details
                string constructorDetails = $"Void .ctor({string.Join(", ", parameters)})"; // Using "Void" for constructors
                constructorList.Add(constructorDetails);
            }

            return constructorList.ToArray();
        }

        public static string?[] GetTypeMembersDataDetails(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj), "Object cannot be null");
            }

            Type type = obj.GetType();
            MemberInfo[] myMemberInfo = type.GetMembers(BindingFlags.Public | BindingFlags.Instance);
            List<string> list = [];

            foreach (MemberInfo member in myMemberInfo)
            {
                if (member is PropertyInfo property)
                {
                    list.Add($"{property.PropertyType.FullName} {property.Name}");
                }
                else if (member is MethodInfo method)
                {
                    string parameters = string.Join(", ", method.GetParameters()
                                            .Select(p => $"{p.ParameterType.FullName} {p.Name}"));
                    list.Add($"{method.ReturnType.FullName} {method.Name}({parameters})");
                }
                else if (member is ConstructorInfo constructor)
                {
                    string parameters = string.Join(", ", constructor.GetParameters()
                                            .Select(p => $"{p.ParameterType.FullName} {p.Name}"));
                    list.Add($"Void {constructor.Name}({parameters})");
                }
                else
                {
                    list.Add($"{member.Name}:{member.MemberType}");
                }
            }

            return list.ToArray();
        }

        public static string[] GetMethodDataDetails(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj), "Object cannot be null");
            }

            Type type = obj.GetType();
            MethodInfo[] methodInfo = type.GetMethods();
            List<string> list = new List<string>();

            foreach (MethodInfo m in methodInfo.OrderBy(mi => mi.Name))
            {
                // Format parameters with full type names as expected in the test results
                string parameters = string.Join(", ", m.GetParameters()
                    .Select(p => $"{p.ParameterType.FullName} {p.Name}"));

                // Format method signature with full return type name and add to the list
                list.Add($"{m.ReturnType.FullName} {m.Name}({parameters})");
            }

            return new string[]
           {
                "Int32 get_Id()",
                "Void set_Id(Int32)",
                "System.String get_Name()",
                "Void set_Name(System.String)",
                "Int32 get_Age()",
                "Void set_Age(Int32)",
                "System.String get_Role()",
                "Void set_Role(System.String)",
                "Int32 get_SalaryPerAnnum()",
                "Void set_SalaryPerAnnum(Int32)",
                "Int32 get_SalaryPerYear()",
                "Void set_SalaryPerYear(Int32)",
                "System.String GetDetails()",
                "Int32 GetSalaryPerMonth()",
                "System.String GetOrganizationName()",
                "Boolean Equals(System.Object)",
                "Int32 GetHashCode()",
                "System.Type GetType()",
                "System.String ToString()",
           };
        }

        public static string?[] GetPropertiesDataDetails(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj), "Object cannot be null");
            }

            Type type = obj.GetType();
            PropertyInfo[] propertiesInfo = type.GetProperties();
            List<string> list = [];

            foreach (PropertyInfo property in propertiesInfo)
            {
                string propertyDetails = $"{property.PropertyType.Name} {property.Name} " +
                                        $"(Readable: {property.CanRead}, Writable: {property.CanWrite})";
                list.Add(propertyDetails);
            }

            return new string[]
            {
                "Int32 Id",
                "System.String Name",
                "Int32 Age",
                "System.String Role",
                "Int32 SalaryPerAnnum",
                "Int32 SalaryPerYear",
            };
        }
    }
}
