var action = 1;

function disableButton() {
    if (action == 1) {
        //SEND DATA TO DB
        //IDEA: DIALOG: ARE YOU SURE YOU WANT TO SEND YOUR REQUEST? Y N
        action = 2;
    }
    else {
        document.getElementById("divRequestSent").style.display = "block"
        setTimeout(function () {
            document.getElementById("divRequestSent").style.display = "none";
        }, 1000);
    }
}
function showHideForm(clicked_id) {
    var x = document.getElementsByClassName("formAdmin");
    var btnStop = document.getElementById("btnStop");
    var btnStart = document.getElementById("btnStart");
    if (clicked_id == "btnStart") {
        btnStop.disabled = false;
        btnStart.disabled = true;
        x[0].style.display = "block";
    }
    else if (clicked_id == "btnStop" && btnStop.disabled == false) {
        x[0].style.display = "none";
        document.getElementById("formDD").style.display = "none";
        btnStop.disabled = true;
        btnStart.disabled = false;
    }
}
function showFormDD() {
    var x = document.getElementById("formDD");
    if (x.style.display === "none")
        x.style.display = "block";
}
function populateSpecialization(studyProg, fac, spec) {
    var studyProg = document.getElementById(studyProg);
    var fac = document.getElementById(fac);
    var spec = document.getElementById(spec);
    spec.innerHTML = "";
    if (studyProg.value == "licenta_zi") {
        if (fac.value == "FABIZ")
            var optionArray = ["|", "Administrarea Afacerilor|Business Administration"];
        else if (fac.value == "FAMP")
            var optionArray = ["|", "Administratie publica|Public administration",
                "Resurse umane|Human resources"];
        else if (fac.value == "BBS")
            var optionArray = ["|", "Bucharest Business School|Bucharest Business School"];
        else if (fac.value == "BT")
            var optionArray = ["|", "Administrarea afacerilor in comert, turism, servicii, merceologie si managementul calitatii|Business Administration on Commerce, Tourism, Services, Commodity Science and Quality Management"];
        else if (fac.value == "CSIE")
            var optionArray = ["|", "Informatica economica|Economic Informatics",
                "Cibernetica economica|Economic Cybernetics",
                "Statistica si previziune economica|Economic Statistics and Previsions"];
        else if (fac.value == "CIG")
            var optionArray = ["|", "Contabilitate si informatica de gestiune|Accounting and management information systems"];
        else if (fac.value == "ETA")
            var optionArray = ["|", "Economie si comunicare economica in afaceri|Economics and Economic Communication in Business"];
        else if (fac.value == "EAM")
            var optionArray = ["|", "Economie agroalimentara si a mediului|AgroFood and Environmental Economics"];
        else if (fac.value == "FABBV")
            var optionArray = ["|", "Finante si banci|Finance and banking"];
        else if (fac.value == "Management")
            var optionArray = ["|", "Management|Management"];
        else if (fac.value == "Marketing")
            var optionArray = ["|", "Marketing|Marketing"];
        else if (fac.value == "REI")
            var optionArray = ["|", "Economie si afaceri internationale|International Business and Economics",
                "Limbi moderne aplicate|Applied Modern Languages"];
    }
    else if (studyProg.value == "master_zi") {
        if (fac.value == "FABIZ")
            var optionArray = ["|", "Antreprenoriat si administrarea afacerilor in domeniul energiei|Entrepreneurship and Business Administration in Energy",
                "Administrarea Afacerilor|Business Administration",
                "Antreprenoriat si Administrarea Afacerilor|Entrepreneurship and Business Administration",
                "Cercetare in afaceri|Business Research",
                "MBA romano-german Management antreprenorial|Management and Entrepreneurship MBA"];
        else if (fac.value == "FAMP")
            var optionArray = ["|", "Administratie publica si integrare europeana|Public administration and european integration",
                "Administratie si management public|Administration and public management",
                "Managementul resurselor umane in sectorul public|Human resources management in public sector"];
        else if (fac.value == "BBS")
            var optionArray = ["|", "MBA Romano-Francez INDE IFR|Romanian - French INDE MBA",
                "Dezvoltarea economica a intreprinderii|Economic development of the company",
                "MBA Romano-Canadian|MBA Romanian-Canadian",
                "MBA Romano-Francez INDE|Romanian-French INDE MBA",
                "MBA romano-german Management antreprenorial|Management and Entrepreneurship MBA"];
        else if (fac.value == "BT")
            var optionArray = ["|", "Administrarea afacerilor comerciale|Business Administration on Commerce",
                "Administrarea afacerilor in turism|Business Administration in Tourism",
                "Business|Business",
                "Excelenta in business si servicii|Excellence in Business and Services",
                "Geopolitica si afaceri|Geopolitics and Business",
                "Management si marketing in turism|Management and Marketing in Tourism",
                "Managementul calitatii|Quality Management",
                "Managementul calitatii, expertize si protectia consumatorului|Quality Management, Expertises and Consumer's Protectio"];
        else if (fac.value == "CSIE")
            var optionArray = ["|", "Analiza afacerilor si controlul performantei intreprinderii|Business Analysis and Enterprise Performance Control",
                "Baze de date - suport pentru afaceri|Data Bases - Support for Business",
                "Cibernetica si economie cantitativa|Cybernetics and Quantitative Economics",
                "E-Business|E-Business",
                "Managementul informatizat al proiectelor|Computerized Project Management",
                "Securitatea informatica|IT&C Security",
                "Sisteme informatice pentru managementul resurselor si proceselor economice|Informatics Systems for the Management of Economic Resources",
                "Statistica|Statistics"];
        else if (fac.value == "CIG")
            var optionArray = ["|", "Analiza financiara si evaluare|Financial analysis and valuation",
                "Audit financiar si consiliere|Financial audit and counseling",
                "Business Services|Business Services",
                "Concepte si practici de audit la nivel national si international|Auditing concepts and practices at national and international levels",
                "Contabilitate internationala|International accounting",
                "Contabilitate si audit in institutii bancare si financiare|Accounting and auditing in financial and banking institutions",
                "Contabilitate, audit si informatica de gestiune|Accounting, auditing and management information systems",
                "Contabilitate, control si expertizs|Accounting, controlling and expertise",
                "Contabilitatea afacerilor|Business Accounting",
                "Contabilitatea si fiscalitatea entitatilor economice|Accounting and taxation of economic entities",
                "Criminologie economico-financiara|Economic Financial Criminology",
                "Drept antreprenorial|Entrepreneurial Law",
                "Economia proprietatilor imobiliare|Real estate economics",
                "Tehnici contabile si financiare de gestiune a afacerilor|counting and finance techniques for business management"];
        else if (fac.value == "ETA")
            var optionArray = ["|", "Analize si strategii economice|Analyses and economic strategies",
                "Comunicare in Afaceri|Business Comunication",
                "Economia si conducerea organizatiilor educationale|Economics and management of educational organizations",
                "Economie Europeana|European Economics"];
        else if (fac.value == "EAM")
            var optionArray = ["|", "Economia si administrarea afacerilor agroalimentare|Economics and administration of agro-food businesses",
                "Economie ecologica|Ecological economics",
                "Managementul proiectelor de dezvoltare rurala si regionala|Management of rural and regional development projects"];
        else if (fac.value == "FABBV")
            var optionArray = ["|", "Banci si asigurari|Banking and insurance",
                "Banci si politici monetare|Banking and Monetary Policies",
                "Cercetari avansate in finante|Advanced research in finance",
                "Finante aplicate|Master of Applied Finance",
                "Finante corporative|Corporate Finance",
                "Finante si banci - DOFIN|Finance and Banking - DOFIN",
                "Fiscalitate|Taxation",
                "Management financiar si investitii|Financial management and investment",
                "Managementul riscului si asigurari|Risc management and insurance",
                "Managementul sistemelor bancare|Banking systems management",
                "Tehnici actuariale|Actuarial techniques"];
        else if (fac.value == "Management")
            var optionArray = ["|", "Consultanta in management si dezvoltarea afacerilor|Management consulting and business development",
                "Management|Management",
                "Management si marketing international|Management and international marketing",
                "Managementul afacerilor|Business management",
                "Managementul afacerilor mici si mijlocii|Small and Medium Enterprises Management",
                "Managementul afacerilor prin proiecte|Business project management",
                "Managementul proiectelor|Project management",
                "Managementul resurselor umane|Human resources management",
                "Managementul serviciilor de sanatate|Healthcare services management"];
        else if (fac.value == "Marketing")
            var optionArray = ["|", "Cercetare fundamentala de marketing|Fundamental Research in Marketing",
                "Cercetari de marketing|Marketing Research", "Managementul marketingului|Marketing Management",
                "Managementul relatiilor cu clientii|Customer Relationship Management", "Marketing international|International Marketing",
                "Marketing online|Online Marketing", "Marketing si comunicare in afaceri|Marketing and Business Communications",
                "Marketing si management in servicii publice|Marketing and Management for Public Services",
                "Marketing strategic|Strategic Marketing",
                "Relatii publice in marketing|Public Relations in Marketing"];
        else if (fac.value == "REI")
            var optionArray = ["|", "Afaceri internationale|International Business",
                "Comert exterior|Foreign trade",
                "Competitivitate si sustenabilitate in mediul de afaceri global|Competitivity and sustenability in global business environment",
                "Comunicare de afaceri in limba engleza|Business Communication in English",
                "Comunicare in limba engleza pentru predare si cercetare economica|English Language Education and Research Communication for Business and Economics",
                "Diplomatie in Economia Internationala|Diplomacy in International Economy",
                "Economie internationala si afaceri europene|International Economics and European Affair",
                "Economie si afaceri internationale|International Business and Economics",
                "Logistica internationala|International Logistics",
                "Managementul Afacerilor Internationale|Management of International Business",
                "Managementul proiectelor internationale|Management of International Projects",
                "Managementul riscului financiar international|Management of International Financial Risk"];
    }
    for (var option in optionArray) {
        var pair = optionArray[option].split("|");
        var newOption = document.createElement("option");
        newOption.value = pair[0];
        newOption.innerHTML = pair[1];
        spec.options.add(newOption);
    }
}
function populateYear(studyProg, year) {
    var studyProg = document.getElementById(studyProg);
    var year = document.getElementById(year);
    year.innerHTML = "";
    if (studyProg.value == "licenta_zi")
        var optionArray = ["|", "1|1", "2|2", "3|3"];
    else if (studyProg.value == "master_zi")
        var optionArray = ["|", "1|1", "2|2"];
    for (var option in optionArray) {
        var pair = optionArray[option].split("|");
        var newOption = document.createElement("option");
        newOption.value = pair[0];
        newOption.innerHTML = pair[1];
        year.options.add(newOption);
    }
}