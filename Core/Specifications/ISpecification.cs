using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria {get;}

        List<Expression<Func<T, object>>> Includes {get;}
         
        //sort 
        Expression<Func<T, object>> OrderBy {get;}
        Expression<Func<T, object>> OrderByDesc {get;}

        //pagination 
        int Take {get;}
        int Skip {get;}
        bool IsPagingEnabled {get;}


    }
}