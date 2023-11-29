using AppDev;
using Microsoft.VisualBasic;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.Remoting;
using System.Text;


CreateClassInteger();
TestClass testClass = new TestClass();
string obj_to_str = ObjectToString(testClass);
Console.WriteLine(obj_to_str);
object str_to_obj = StringToObject(obj_to_str);


static string ObjectToString(object obj)
{
    StringBuilder builder = new StringBuilder($"{obj.GetType().ToString()}\n");
    builder.Append($"{obj.GetType().Assembly}\n");
    builder.Append($"{obj.GetType().Name}\n");
    var properties = obj.GetType().GetProperties();

    foreach(var property in properties)
    {
        builder.Append($"{property.PropertyType}\n");
        var value = property.GetValue(obj);
        builder.Append($"{GetPropertyName(property)}: ");
        if (property.PropertyType == typeof(char[]))
        {
            if (property.GetValue(obj, null) != null)
            {
                foreach(char val in property.GetValue(obj, null) as char[]) 
                    builder.Append($"{val}\n");
            }
        }
        else
            builder.Append($"{value}\n");
    }
    return builder.ToString();
}

static string GetPropertyName(PropertyInfo property)
{
    var customNameAttribute = (CustomNameAttribute)Attribute.GetCustomAttribute(property, typeof(CustomNameAttribute));
    return customNameAttribute != null ? customNameAttribute.CustomFieldName : property.Name;
}

static object StringToObject(string str)
{
    string[] parse_properties = str.Split("\n");
    object obj = Activator.CreateInstance(null, parse_properties[0]).Unwrap();
    Type type = obj.GetType();
    var properties = type.GetProperties();
    for(int i = 1; i < parse_properties.Length; i++)
    {
        var property = type.GetProperty(parse_properties[i + 1]);
        if (property.PropertyType == typeof(int))
            property.SetValue(obj, int.Parse(parse_properties[i + 2]));
        if (property.PropertyType == typeof(string))
            property.SetValue(obj, parse_properties[i + 2].ToString());
        if (property.PropertyType == typeof(decimal))
            property.SetValue(obj, decimal.Parse(parse_properties[i + 2]));
        if (property.PropertyType == typeof(char))
            property.SetValue(obj, char.Parse(parse_properties[i + 2]));
    }
    return obj;
}

void CreateClassInteger()
{
    Console.WriteLine("Creating class Integer");
    var type = typeof(TestClass);
    var obj1 = Activator.CreateInstance(type);
    var obj2 = Activator.CreateInstance(type, new Object[] { 1 });
    var obj3 = Activator.CreateInstance(type, new Object[] { 1, "string", 0.7, new char[] { 'c', 'h', 'a', 'r'} });
}