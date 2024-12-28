import js from '@eslint/js'
import pluginVue from 'eslint-plugin-vue'
import skipFormatting from '@vue/eslint-config-prettier/skip-formatting'
import prettier from '@vue/eslint-config-prettier'

export default [
  {
    name: 'app/files-to-lint',
    files: ['**/*.{js,mjs,jsx,vue}'],
  },

  {
    name: 'app/files-to-ignore',
    ignores: ['**/dist/**', '**/dist-ssr/**', '**/coverage/**'],
  },
  {
    files: ['**/*.{js,vue}'],
    ignores: ['**/dist/**', '**/node_modules/**'],
    languageOptions: {
      parserOptions: {
        ecmaVersion: 'latest',
        sourceType: 'module',
      },
    },
    rules: {
      ...js.configs.recommended.rules, // Quy tắc cơ bản của JavaScript
      ...pluginVue.configs['flat'].rules, // Quy tắc của Vue 3
      'no-unused-vars': 'off', // Tắt cảnh báo biến không sử dụng
      'vue/no-multiple-template-root': 'off', // Tắt cảnh báo multiple root (Vue 3 hỗ trợ)
      'vue/no-v-html': 'off', // Tắt cảnh báo v-html nếu bạn cần
    },
  },

  js.configs.recommended,
  ...pluginVue.configs['flat/essential'],
  skipFormatting,
]
