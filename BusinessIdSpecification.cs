using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System;

public class BusinessIdSpecification : ISpecification<string>
{   
    List<string> errors;

    public BusinessIdSpecification()
    {
        this.errors = new List<string>();
    }


    public IEnumerable<string> ReasonsForDissatisfaction
    {
        get
        {
            return errors;
        }
    }


    public bool IsSatisfiedBy(string entity)
    {
        Validator validator = new Validator(entity);
        this.errors = validator.Errors();

        if (errors.Count > 0)
        {
            return false;
        }
        return true;
    }


}
