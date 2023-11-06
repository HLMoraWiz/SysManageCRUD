﻿using SysManageCRUD.Models;

namespace SysManageCRUD.Repository
{
    public interface ISpecialtyRepository
    {
        Specialty GetSpecialty(int id);
        List<Specialty> GetSpecialtyList();
        Specialty UpdateSpecialty(Specialty specialty);
        void DeleteSpecialty(int id);
        Specialty CreateSpecialty(Specialty specialty);

    }
}