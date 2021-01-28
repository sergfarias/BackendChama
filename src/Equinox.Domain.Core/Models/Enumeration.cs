using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace Equinox.Domain.Core.Models
{

    public abstract class Enumeration<T> : IComparable<T> where T : Enumeration<T>
    {

        public int Id { get; protected set; }
        public string Nome { get; protected set; }


        protected Enumeration(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public override string ToString() => Nome;

        public static IEnumerable<T> ObterTodos()
        {
            var fields = typeof(T).GetFields(BindingFlags.Public |
                                             BindingFlags.Static |
                                             BindingFlags.DeclaredOnly
                );

            return fields.Select(f => f.GetValue(null)).Cast<T>().OrderBy(e => e.Id);
        }
        
        public static T ObterPorId(int id)
        {
            return ObterTodos().Where(t => t.Id == id).FirstOrDefault();
        }

        public static T ObterPorNome(string nome)
        {
            return ObterTodos().Where(t => t.Nome == nome).FirstOrDefault();
        }


        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration<T>;
            if (otherValue==null) 
                return false;

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        public static bool operator ==(Enumeration<T> a, Enumeration<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return false;

            return a.Equals(b);


        }

        public static bool operator !=(Enumeration<T> a, Enumeration<T> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public int CompareTo([AllowNull] T other) => Id.CompareTo((other).Id);
    }

}
