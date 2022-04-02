import * as api from './api.js';

const endpoints = {
    'theaters': '/data/theaters',
    'likes': '/data/likes'
};

export async function get(){
    return api.get(endpoints.theaters + '?sortBy=_createdOn%20desc&distinct=title');
}

export async function create(theater){
    return api.post(endpoints.theaters, theater);
}

export async function getById(id){
    return api.get(endpoints.theaters + `/${id}`);
}

export async function getMine(userId){
    return api.get(endpoints.theaters + `?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

export async function edit(theater, id){
    return api.put(endpoints.theaters + `/${id}`, theater);
}

export async function remove(id){
    return api.delete(endpoints.theaters + `/${id}`);
}


export async function like(data){
    return api.post(endpoints.likes, data);
}

export async function getLikes(id){
    return api.get(endpoints.likes + `?where=bookId%3D%22${id}%22&distinct=_ownerId&count`)
}

export async function isLiked(userId, bookId){
    return api.get(endpoints.likes + `?where=bookId%3D%22${bookId}%22%20and%20_ownerId%3D%22${userId}%22&count`)
}