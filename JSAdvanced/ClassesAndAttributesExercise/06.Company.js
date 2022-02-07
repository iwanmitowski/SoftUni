class Company{
    
    constructor(){
        this.departments = {};
    }

    addEmployee(name, salary, position, department){

        let arr = [name, salary, position, department];

        if (arr.includes('') || 
            arr.includes(undefined) ||
            arr.includes(null) ||
            Number(salary) < 0) {
            throw new Error('Invalid input!');
        }

        if (!this.departments[department]) {
            this.departments[department] = {};
            this.departments[department].employees = [];
        }

        this.departments[department].employees.push({
            name,
            salary: Number(salary),
            position,
        });

        return `New employee is hired. Name: ${name}. Position: ${position}`;
    }

    bestDepartment(){

        let bestDepartmentAvgSalary = 0;
        let bestDepartment;
        let bestDepartmentName;

        for (const department in this.departments) {
            this.departments[department].avgSalary = (this.departments[department].employees.reduce((a, b) => a += b.salary, 0) / this.departments[department].employees.length);
            
            if (bestDepartmentAvgSalary < this.departments[department].avgSalary) {
                bestDepartmentAvgSalary = this.departments[department].avgSalary;
                bestDepartment = this.departments[department];
                bestDepartmentName = department;
            }
        }

        bestDepartment.employees.sort((a, b) => b.salary - a.salary || a.name.localeCompare(b.name))

        return `Best Department is: ${bestDepartmentName}\nAverage salary: ${bestDepartmentAvgSalary.toFixed(2)}\n${bestDepartment.employees.map(e => `${e.name} ${e.salary} ${e.position}`).join('\n')}`;
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());
