import * as api from './api.js';

const endpoints = {
    'posts': '/data/posts',
    'donation': '/data/donations',
};

export async function get(){
    return api.get(endpoints.posts + '?sortBy=_createdOn%20desc');
}

export async function getById(id){
    return api.get(endpoints.posts + `/${id}`);
}

export async function getMine(userId){
    return api.get(endpoints.posts + `?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

export async function create(post){
    return api.post(endpoints.posts, post);
}

export async function remove(id){
    return api.delete(endpoints.posts + `/${id}`);
}

export async function edit(post, id){
    return api.put(endpoints.posts + `/${id}`, post);
}

export async function donate(post){
    return api.post(endpoints.donation, post);
}

export async function getDonationCount(postId){
    return api.get(endpoints.donation + `?where=postId%3D%22${postId}%22&distinct=_ownerId&count`)
}

export async function isDonated(postId, userId){
    return api.get(endpoints.donation + `?where=postId%3D%22${postId}%22%20and%20_ownerId%3D%22${userId}%22&count`);
}