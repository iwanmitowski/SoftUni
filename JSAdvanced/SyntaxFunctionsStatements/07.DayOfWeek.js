function getDay(day){
    let dayNumber;

    switch(day){
        case 'Monday':
            numberOfDay = 1;
            break;
        case 'Tuesday':
            numberOfDay = 2;
            break;
        case 'Wednesday':
            numberOfDay = 3;
            break;
        case 'Thursday':
            numberOfDay = 4;
            break;
        case 'Friday':
            numberOfDay = 5;
            break;
        case 'Saturday':
            numberOfDay = 6;
            break;
        case 'Sunday':
            numberOfDay = 7;
            break;
        default:
            numberOfDay = 'error';
            break;
    }
    
    return numberOfDay;
}