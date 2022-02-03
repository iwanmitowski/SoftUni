function validate(request){

    let versions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0']
    
    let methods = ['GET', 'POST', 'DELETE', 'CONNECT'];

    if (!request.hasOwnProperty('method') || !methods.includes(request.method)) {
        throw new Error(`Invalid request header: Invalid Method`);
    }

    if (!request.hasOwnProperty('uri') || !/^([\w\d\.]+|\*)$/.test(request.uri)) {
        throw new Error(`Invalid request header: Invalid URI`);
    }

    if (!request.hasOwnProperty('version') || !versions.includes(request.version)) {
        throw new Error(`Invalid request header: Invalid Version`);
    }

    if (!request.hasOwnProperty('message') || !/^([^<>\\&'"]*)$/.test(request.message)) {
        throw new Error(`Invalid request header: Invalid Message`);
    }

    return request;
}

validate({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
} 
  );