﻿using System.Security.Cryptography.X509Certificates;
using Org.BouncyCastle.Utilities;

namespace EntityFrameworkContext;

public class Service
{
    private SakilaDataContext sakilaDataContext; 
    public Service(SakilaDataContext sakilaDataContext) {
        this.sakilaDataContext = sakilaDataContext; 
    }
 
}
