using System;
using UnityEngine;

public enum TypeBlessing { Humidity, Speed, DashSpeed, DashDuration, MaxHealth, DamageResistance, Miscellaneous, Damage }
public class Blessing
{
    public string _name;
    public string _description;
    public TypeBlessing _type;
    public float _value;

    public Blessing(string name, string description,  TypeBlessing type, float value)
    {
        _name = name;
        _description = description;
        _type = type;
        _value = value;
    }

    public override string ToString()
    {
        return $"<size=200%><b>{_name}</b></size>\n\n" + $"Tipo: {_type}\n" + $"Valor: {_value}\n" + $"{_description}"; 
    }
}
