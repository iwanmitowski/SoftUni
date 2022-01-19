function solve(worker){
    let {weight, experience, levelOfHydrated, dizziness} = worker;

    if (dizziness) {
        let neededWater = weight * 0.1 * experience;
        worker.levelOfHydrated += neededWater;
        worker.dizziness = false;
    }

    return worker
}

solve({ weight: 95,
    experience: 3,
    levelOfHydrated: 0,
    dizziness: false }
  );