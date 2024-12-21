using System.Reflection;
using NUnit.Framework;

[assembly: CLSCompliant(true)]

namespace Reflection.Tests
{
    [TestFixture]
    public class ReflectionOperationsTests
    {
        private static readonly object[][] GetTypeNameData = new object[][]
        {
            [new ForTestingClass(), "ForTestingClass"],
            [new Employee(101, "Rahul", 22, "JSE", 600000, 45000), "Employee"],
        };

        private static readonly object[][] GetFullTypeNameData = new object[][]
        {
            [typeof(ForTestingClass), "Reflection.Tests.ForTestingClass"],
            [typeof(Employee), "Reflection.Tests.Employee"],
        };

        private static readonly object[][] GetAssemblyQualifiedNameData = new object[][]
        {
            [
                typeof(ForTestingClass),
                "Reflection.Tests.ForTestingClass, Reflection.Tests, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"
            ],
            [
                typeof(Employee),
                "Reflection.Tests.Employee, Reflection.Tests, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"
            ],
        };

        private static readonly object[][] GetPrivateInstanceFieldsData = new object[][]
        {
            [new ForTestingClass(), new string[] { "intField" }],
            [
                new Employee(101, "Rahul", 22, "JSE", 600000, 45000),
                new string[]
                {
                    "<Id>k__BackingField", "<Name>k__BackingField", "<Age>k__BackingField", "<Role>k__BackingField",
                    "<SalaryPerAnnum>k__BackingField", "<SalaryPerYear>k__BackingField",
                }
            ],
        };

        private static readonly object[][] GetPublicStaticFieldsData = new object[][]
        {
            [new ForTestingClass(), new string[] { "StaticIntField" }],
            [
                new Employee(101, "Rahul", 22, "JSE", 600000, 45000), Array.Empty<string>()
            ],
        };

        private static readonly object[][] GetInterfaceData = new object[][]
        {
            [new Employee(103, "Suresh", 23, "SE", 700000, 55000), new string[] { "Reflection.Tests.IEmployee" }],
        };

        private static readonly object[][] GetConstructorsData = new object[][]
        {
            [
                new Employee(104, "Salman", 24, "SE", 700000, 55000),
                new string[] { "Void .ctor(Int32, System.String, Int32, System.String, Int32, Int32)" }
            ],
        };

        private static readonly object[][] GetTypeMembersData = new object[][]
        {
            [
                new Employee(105, "Chris", 27, "SSE", 1000000, 100000),
                new string[]
                {
                    "Int32 get_Id()", "Void set_Id(Int32)", "System.String get_Name()", "Void set_Name(System.String)",
                    "Int32 get_Age()", "Void set_Age(Int32)", "System.String get_Role()", "Void set_Role(System.String)",
                    "Int32 get_SalaryPerAnnum()", "Void set_SalaryPerAnnum(Int32)", "Int32 get_SalaryPerYear()",
                    "Void set_SalaryPerYear(Int32)", "System.String GetDetails()", "Int32 GetSalaryPerMonth()",
                    "System.String GetOrganizationName()", "Boolean Equals(System.Object)", "Int32 GetHashCode()",
                    "System.Type GetType()", "System.String ToString()",
                    "Void .ctor(Int32, System.String, Int32, System.String, Int32, Int32)", "Int32 Id",
                    "System.String Name", "Int32 Age", "System.String Role", "Int32 SalaryPerAnnum", "Int32 SalaryPerYear",
                }
            ],
        };

        private static readonly object[][] GetMethodData = new object[][]
        {
            [
                new Employee(106, "John", 25, "SSE", 1000000, 100000),
                new string[]
                {
                    "Int32 get_Id()", "Void set_Id(Int32)", "System.String get_Name()", "Void set_Name(System.String)",
                    "Int32 get_Age()", "Void set_Age(Int32)", "System.String get_Role()", "Void set_Role(System.String)",
                    "Int32 get_SalaryPerAnnum()", "Void set_SalaryPerAnnum(Int32)", "Int32 get_SalaryPerYear()",
                    "Void set_SalaryPerYear(Int32)", "System.String GetDetails()", "Int32 GetSalaryPerMonth()",
                    "System.String GetOrganizationName()", "Boolean Equals(System.Object)", "Int32 GetHashCode()",
                    "System.Type GetType()", "System.String ToString()",
                }
            ],
        };

        private static readonly object[][] GetPropertiesData = new object[][]
        {
            [
                new Employee(108, "Vivek", 24, "JSE", 600000, 45000),
                new string[]
                {
                    "Int32 Id", "System.String Name", "Int32 Age", "System.String Role", "Int32 SalaryPerAnnum",
                    "Int32 SalaryPerYear",
                }
            ],
        };

        [TestCaseSource(nameof(GetTypeNameData))]
        public void GetTypeName_ReturnsTypeName(object obj, string expected)
        {
            // Act
            string actual = ReflectionOperations.GetTypeName(obj);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(GetFullTypeNameData))]
        public void GetFullTypeName_ReturnsFullTypeName(Type type, string expected)
        {
            // Arrange
            MethodInfo? methodInfo = typeof(ReflectionOperations).GetMethod(
                nameof(ReflectionOperations.GetFullTypeName),
                BindingFlags.Static | BindingFlags.Public);
            MethodInfo genericMethodInfo = methodInfo!.MakeGenericMethod(type);

            // Act
            object? actual = genericMethodInfo.Invoke(null, null);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(GetAssemblyQualifiedNameData))]
        public void GetAssemblyQualifiedName_ReturnsAssemblyQualifiedName(Type type, string expected)
        {
            // Arrange
            MethodInfo? methodInfo = typeof(ReflectionOperations).GetMethod(
                nameof(ReflectionOperations.GetAssemblyQualifiedName),
                BindingFlags.Static | BindingFlags.Public);
            MethodInfo genericMethodInfo = methodInfo!.MakeGenericMethod(type);

            // Act
            object? actual = genericMethodInfo.Invoke(null, null);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(GetPrivateInstanceFieldsData))]
        public void GetPrivateInstanceFields(object obj, string[] expected)
        {
            // Act
            string[] actual = ReflectionOperations.GetPrivateInstanceFields(obj);

            // Assert
            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [TestCaseSource(nameof(GetPublicStaticFieldsData))]
        public void GetPublicStaticFields(object obj, string[] expected)
        {
            // Act
            string[] actual = ReflectionOperations.GetPublicStaticFields(obj);

            // Assert
            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [TestCaseSource(nameof(GetInterfaceData))]
        public void GetInterfaceDataDetails(object obj, string[] expected)
        {
            // Act
            string?[] actual = ReflectionOperations.GetInterfaceDataDetails(obj);

            // Assert
            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [TestCaseSource(nameof(GetConstructorsData))]
        public void GetConstructorsDataDetails(object obj, string[] expected)
        {
            // Act
            string?[] actual = ReflectionOperations.GetConstructorsDataDetails(obj);

            // Assert
            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [TestCaseSource(nameof(GetTypeMembersData))]
        public void GetTypeMembersDataDetails(object obj, string[] expected)
        {
            // Act
            string?[] actual = ReflectionOperations.GetTypeMembersDataDetails(obj);

            // Assert
            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [TestCaseSource(nameof(GetMethodData))]
        public void GetMethodDataDetails(object obj, string[] expected)
        {
            // Act
            string?[] actual = ReflectionOperations.GetMethodDataDetails(obj);

            // Assert
            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [TestCaseSource(nameof(GetPropertiesData))]
        public void GetPropertiesDataDetails(object obj, string[] expected)
        {
            // Act
            string?[] actual = ReflectionOperations.GetPropertiesDataDetails(obj);

            // Assert
            Assert.That(actual, Is.EquivalentTo(expected));
        }
    }
}
