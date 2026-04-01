import { createFileRoute, Outlet } from '@tanstack/react-router'

export const Route = createFileRoute('/_auth')({
  beforeLoad: () => {
    // auth check
  },
  component: AuthLayout,
})

function AuthLayout() {
  return <Outlet />
}
