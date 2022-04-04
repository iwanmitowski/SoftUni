import * as api from './api.js';

const endpoints = {
    'books': '/data/books',
    'likes': '/data/likes',
};

export async function get(){
    return api.get(endpoints.books + '?sortBy=_createdOn%20desc');
}

export async function getById(id){
    return api.get(endpoints.books + `/${id}`);
}

export async function getMine(id){
    return api.get(endpoints.books + `?where=_ownerId%3D%22${id}%22&sortBy=_createdOn%20desc`);
}

export async function create(book){
    return api.post(endpoints.books, book);
}

export async function remove(id){
    return api.delete(endpoints.books + `/${id}`);
}

export async function edit(book, id){
    return api.put(endpoints.books + `/${id}`, book);
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