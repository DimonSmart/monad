using System;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;

namespace MonadSample
{
    internal class Either<T, TE> where TE : Exception
    {
        private readonly Exception _error;
        private readonly T _value;

        private Either(T value)
        {
            _value = value;
            _error = default(TE);
        }

        private Either(Exception error)
        {
            _value = default(T);
            _error = error;
        }

        public static Either<T, TE> Pure(T value)
        {
            return new Either<T, TE>(value);
        }

        public static Either<T2, TE> Bind<T2>(Either<T, TE> mValue, Func<T, Either<T2, TE>> action)
        {
            if (mValue._error != null)
            {
                return new Either<T2, TE>(mValue._error);
            }

            try
            {
                return action(mValue._value);
            }
            catch (Exception exception)
            {
                return new Either<T2, TE>(exception);
            }
        }
    }

    public class DbEntity
    {

    }

    public class Entity
    {

    }

    public class WorkFlow
    {
        void Go()
        {
            var intValue = 10;
            var mIntValue = Either<int, Exception>.Pure(intValue);
            var eResult = Either<int, Exception>
                .Bind(Either<int, Exception>.Pure(intValue),
                GetItemFromDb);
            
            
            
            // arg => { return Either<DbEntity, Exception>.Bind(GetItemFromDb(arg)); }

            




        }

        private Either<DbEntity, Exception> GetItemFromDb(int i)
        {
            Debug.Write($"Get item from db:{i}");
            return Either<DbEntity, Exception>.Pure(new DbEntity());
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}