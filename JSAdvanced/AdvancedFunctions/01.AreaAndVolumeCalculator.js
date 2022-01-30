function solve(area, vol, input){

    let result = [];

    JSON.parse(input).forEach(coordinates => {

        coordinates.area = area;
        coordinates.vol = vol;

        result.push({
            area: coordinates.area(),
            volume: coordinates.vol()
        })
    });

    return result;
}

solve(`[
    {"x":"1","y":"2","z":"10"},
    {"x":"7","y":"7","z":"10"},
    {"x":"5","y":"2","z":"10"}
    ]`
    );
