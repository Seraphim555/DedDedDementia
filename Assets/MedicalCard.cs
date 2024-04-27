using System;
using UnityEngine;
using UnityEngine.UI;


public class MedicalCard : MonoBehaviour
{

    public const string Title = "Медицинская карта";

    private DateTime _today = DateTime.Today;

    public string Address { get; set; }
    public string DateOfBirth { get; set; }

    public string Fullname { get; set; }

    public string Description { get; set; }

    public string[] Diseases { get; set; }

    public MedicalCard(string address, string dateOfBirth, string fullname, string description, string[] diseases)
    {
        Address = address;
        DateOfBirth = dateOfBirth;
        Fullname = fullname;
        Description = description;
        Diseases = diseases;
    }
}