using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Equinox.Domain.Core.Models
{

    public abstract class Entity<T> : AbstractValidator<T> where T : Entity<T>
    {

        public int Id { get; protected set; }
        public virtual ValidationResult ValidationResult { get; protected set; }

        protected Entity()
        {
            ValidationResult = new ValidationResult();
        }

        public abstract bool IsValid();

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity<T>;
            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(this, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity<T> a, Entity<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return false;

            return a.Equals(b);


        }

        public static bool operator !=(Entity<T> a, Entity<T> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + "[Id=" + Id + "]";
        }

        protected void AdicionarErroDeValidacao(ValidationFailure error) 
        {
            ValidationResult.Errors.Add(error);
        }

        protected void AdicionarErroDeValidacao(ValidationResult validationResult)
        {
            AdicionarErroDeValidacao(validationResult.Errors);
        }

        protected void AdicionarErroDeValidacao(IEnumerable<ValidationFailure> errors)
        {
            foreach (var error in errors) AdicionarErroDeValidacao(error);
        }

    }

}
