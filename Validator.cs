using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System;

public class Validator
{
    string entity;
    List<string> errors;

    public Validator(string entity)
    {
        this.entity = entity;
        this.errors = new List<string>();
    }


    public List<string> Errors()
    {
        Length();
        OnlyNumbers();
        ChecknumberIsValid();

        return this.errors;
    }


    public void Length()
    {
        if (entity.Length > 9)
        {
            errors.Add("Id is too long");
        }
        else if (entity.Length < 9)
        {
            errors.Add("Id is too short");
        }
    }


    public void OnlyNumbers()
    {
        Regex regex = new Regex(@"[^0-9,-]");
        Match match = regex.Match(entity);
        if (match.Success)
        {
            errors.Add("Id may contain only numbers and hyphen");
        }
    }


    public bool IsInCorrectForm()
    {
        Regex regex = new Regex(@"^[0-9]{7}\-[0-9]{1}$");
        Match match = regex.Match(entity);
        if (!match.Success)
        {
            errors.Add("Id is not in correct form (NNNNNNN-Y)");
            return false;
        }
        return true;
    }


    public void ChecknumberIsValid()
    {
        if (IsInCorrectForm())
        {
            string checknumber = CheckNumber(entity).ToString();
            if (checknumber.Equals("1") || !entity.EndsWith(checknumber))
            {
                errors.Add("Wrong checknumber, id is not valid");
            }
        }
    }


    // Calculates the correct checknumber
    public int CheckNumber(string beginning)
    {
        var x = beginning.ToCharArray();
        int sum = (x[0] - '0') * 7
                + (x[1] - '0') * 9
                + (x[2] - '0') * 10
                + (x[3] - '0') * 5
                + (x[4] - '0') * 8
                + (x[5] - '0') * 4
                + (x[6] - '0') * 2;
        int mod = sum % 11;

        if (mod == 0 || mod == 1)
        {
            return mod;
        }
        else
        {
            return 11 - mod;
        }
    }

}