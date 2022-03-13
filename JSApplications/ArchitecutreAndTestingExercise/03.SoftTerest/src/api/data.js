import * as api from './api.js';

const endpoints = {
    'ideas': '/data/ideas?select=_id%2Ctitle%2Cimg&sortBy=_createdOn%20desc',
    'idea': '/data/ideas/',
};

export async function createIdea(idea){
    return api.post(endpoints.idea, idea);
}

export async function getAllIdeas(){
    return api.get(endpoints.ideas);
}

export async function getIdea(id){
    return api.get(endpoints.idea + id);
}

export async function deleteIdea(id){
    return api.delete(endpoints.idea + id);
}