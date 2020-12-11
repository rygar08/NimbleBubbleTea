import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'Bubble Tea Bonanza',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44322',
    redirectUri: baseUrl,
    clientId: 'Nm_App',
    responseType: 'code',
    scope: 'offline_access Nm',
  },
  apis: {
    default: {
      url: 'https://localhost:44322',
      rootNamespace: 'Nm',
    },
  },
} as Environment;
