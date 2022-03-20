import * as api from './api.js';

const endpoints = {
    'teams': '/data/teams',
    'members': '/data/members',
};

export async function getAllData(){
    return api.get(endpoints.teams);
}

export async function getAllMembers(){
    return api.get(endpoints.members + `?where=status%3D%22member%22`);
}

export async function getAllMembersInGivenTeams(teamIds){
    console.log(encodeURIComponent(`?where=teamId IN (${teamIds}) AND status="member"`));
    return api.get(endpoints.members + encodeURIComponent(`?where=teamId IN (${teamIds}) AND status="member"`));
}

export async function getDataById(id){
    return api.get(endpoints.teams + `/${id}`);
}

export async function deleteData(id){
    return api.delete(endpoints.teams + `/${id}`);
}

export async function createFurniture(data){
    return api.post(endpoints.teams, data)
}

export async function editData(id, data) {
    return await api.put(endpoints.teams + `/${id}`, data);
}
